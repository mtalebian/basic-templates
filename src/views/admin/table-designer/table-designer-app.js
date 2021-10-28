import React, { useState, useEffect } from "react";

import * as bd from "react-basic-design";
//import accountManager from "../../../app/account-manager";

import classNames from "classnames";
import { tableDesignerApi } from "../../../api/table-designer-api";
import { TableDesignerEditGroup } from "./edit-group";
import { TableDesignerEditTable } from "./edit-table";
import { notify } from "../../../components/basic/notify";
import { Tile, Tiles } from "../../../components/tilemenu/tiles";
import * as icons from "../../../assets/icons";
import { useTranslation } from "react-i18next";
import { useAccount } from "../../../app/account-context";

//
export function TableDesignerApp() {
    const account = useAccount();
    const { t } = useTranslation();
    const [groups, setGroups] = useState(null);
    const [group, setGroup] = useState(null);
    const [table, setTable] = useState(null);
    const [column, setColumn] = useState(null);

    function goBack() {
        if (column) {
            setColumn(null);
            return;
        }
        if (group) setGroup(null);
        if (table) setTable(null);
    }

    function onEditGroupClick(g) {
        setGroup(g);
        return false;
    }

    function onAddFormClick(g) {
        setGroup(g);
        setTable({ data: { dataColumns: [] } });
        return false;
    }

    function onEditTableClick(g, t) {
        if (t.data) {
            setGroup(g);
            setTable(t);
            return false;
        }
        tableDesignerApi
            .getTable(t.name)
            .then((x) => {
                t.data = x;
                setGroup(g);
                setTable(t);
            })
            .catch((ex) => {
                notify.error(ex);
            });
        return false;
    }

    function onAddGroupClicked() {
        setGroup({ title: "" });
    }

    useEffect(() => {
        if (!groups && account.isConnected()) {
            tableDesignerApi.getGroups().then((x) => setGroups(x));
        }
        // return accountManager.status.onConnected(function () {
        //     if (!groups) tableDesignerApi.getGroups().then((x) => setGroups(x));
        // }).remove;
    }, [groups, account]);

    return (
        <>
            <div className={classNames({ "d-none": group || table })}>
                <div className="border-bottom bg-gray-5 mb-3">
                    <bd.Toolbar className="container">
                        <bd.Button color="primary" size="sm" onClick={onAddGroupClicked}>
                            <icons.Folder />
                            {t("add-new-group")}
                        </bd.Button>
                    </bd.Toolbar>
                </div>
                <div className="container">
                    <Tiles>
                        {groups &&
                            groups
                                .sort((a, b) => (a.title === b.title ? 0 : a.title > b.title ? 1 : -1))
                                .map((g) => (
                                    <Tile
                                        key={g.id}
                                        title={
                                            <>
                                                <span className="size-md"> {g.title}</span>
                                                <bd.Button
                                                    variant="text"
                                                    size="sm"
                                                    className="mx-2"
                                                    color="secondary"
                                                    onClick={() => onEditGroupClick(g)}
                                                >
                                                    <icons.Edit />
                                                    Edit Group
                                                </bd.Button>
                                                <bd.Button variant="text" size="sm" color="secondary" onClick={() => onAddFormClick(g)}>
                                                    <icons.Add />
                                                    New table
                                                </bd.Button>
                                            </>
                                        }
                                    >
                                        {g.items.map((t) => (
                                            <Tile key={t.name} title={t.title} onClick={() => onEditTableClick(g, t)} />
                                        ))}
                                    </Tile>
                                ))}
                    </Tiles>
                </div>
            </div>

            {group && !table && !column && (
                <TableDesignerEditGroup
                    onGoBack={goBack}
                    group={group}
                    onChanged={(g) => {
                        if (!g) {
                            var i = groups.indexOf(group);
                            groups.splice(i, 1);
                            goBack();
                            setGroups(groups);
                            return;
                        }
                        for (let i = 0; i < groups.length; i++) {
                            if (groups[i].id === g.id) {
                                groups[i] = g;
                                goBack();
                                setGroups(groups);
                                return;
                            }
                        }
                        groups.push(g);
                        goBack();
                        setGroups(groups);
                    }}
                />
            )}

            {group && table && !column && (
                <TableDesignerEditTable
                    onGoBack={goBack}
                    group={group}
                    table={table.data}
                    onChanged={(tb, tbName) => {
                        var g = groups.find((x) => x.id === group.id);
                        var t = g.items.find((x) => x.name === (tb ? tb.name : tbName));
                        if (!tb) {
                            // removed
                            g.items = g.items.filter((x) => x !== t);
                        } else if (!t) {
                            // added
                            g.items.push({
                                name: tb.name,
                                title: tb.title,
                                table: tb,
                            });
                        } else {
                            // modifed
                            t.title = tb.title;
                            t.data = tb;
                        }
                        goBack();
                        setGroups(groups);
                    }}
                />
            )}
        </>
    );
}

TableDesignerApp.Appbar = {
    title: "Table Designer",
    buttons: null,
};
