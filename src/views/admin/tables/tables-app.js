import React, { useEffect, useState } from "react";
import * as bd from "react-basic-design";
//import * as icons from "../../../assets/icons";
import { useTranslation } from "react-i18next";
import { useAccount } from "../../../app/account-context";
import { Tile, Tiles } from "../../../components/tilemenu/tiles";
import { tablesApi } from "../../../api/tables-api";
import { notify } from "../../../components/basic/notify";
import { BrowseTable } from "./browse-base-table";
import { Text } from "../../../components/basic/text";

export function TablesApp() {
    const account = useAccount();
    const { t } = useTranslation();
    const [groups, setGroups] = useState(null);
    const [table, setTable] = useState(null);

    const onTableClick = (t) => {
        if (t.schema) {
            setTable(t);
            return;
        }
        tablesApi
            .browseTable(t.name)
            .then((x) => {
                t.data = x.data;
                t.schema = x.schema;
                setTable(t);
            })
            .catch((ex) => {
                notify.error(ex);
            });
    };

    useEffect(() => {
        if (!groups && account.isConnected()) {
            tablesApi.getGroups().then((x) => setGroups(x));
        }
    }, [groups, account]);

    return (
        <>
            {!table && (
                <>
                    <div className="border-bottom bg-gray-5 mb-3">
                        <bd.Toolbar className="container">
                            <h5 className="text-secondary-text">{t("select-a-table...")}</h5>
                        </bd.Toolbar>
                    </div>
                    <div className="container">
                        <Tiles>
                            {groups &&
                                groups
                                    .sort((a, b) => (a.title === b.title ? 0 : a.title > b.title ? 1 : -1))
                                    .map((g) => (
                                        <Tile key={g.id} title={g.title}>
                                            {g.items.map((t) => (
                                                <Tile key={t.name} title={t.title} onClick={(e) => onTableClick(t)} />
                                            ))}
                                        </Tile>
                                    ))}
                        </Tiles>
                    </div>
                </>
            )}

            {table && <BrowseTable table={table} onGoBack={() => setTable(null)} />}
        </>
    );
}

TablesApp.Appbar = {
    title: "basic-tables",
    buttons: null,
};
