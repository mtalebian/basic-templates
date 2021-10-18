import React, { useMemo, useRef, useState } from "react";
import { useTranslation } from "react-i18next";
import { Formik } from "formik";
import * as yup from "yup";
import * as bd from "react-basic-design";
import * as icons from "../../../assets/icons";
import { messages } from "../../../components/messages";
import { tableDesignerApi } from "../../../api/table-designer-api";
import { notify } from "../../../components/basic/notify";
import { TableTitlebar } from "../../../components/table";
import { BasicInput } from "../../../components/basic-form/basic-input";
import {
    useTable,
    useGlobalFilter,
    usePagination,
    useSortBy,
    useFilters,
    useGroupBy,
    useExpanded,
    useRowSelect,
    //useBlockLayout,
    useFlexLayout,
    //useRowState,
    //useResizeColumns,
} from "react-table";
import { RenderTableDiv } from "../../../components/table/render-table-div";
import { DefaultEditor } from "../../../components/table/editors";
import { BasicTextArea } from "../../../components/basic-form/basic-textarea";

//
export function TableDesignerEditTable({ table, group, onChanged, onGoBack }) {
    const { t } = useTranslation();
    const [data, setData] = useState(table.columns);
    const [saving, setSaving] = useState(false);
    const [deleting, setDeleting] = useState(false);
    const insertMode = !table.name;
    const formRef = useRef();

    const onSaveClick = () => {
        var values = formRef.current.values;
        setSaving(true);
        var dto = { ...values, dataColumns: data };
        tableDesignerApi
            .saveTable(group.id, dto, insertMode)
            .then((x) => {
                setSaving(false);
                notify.info(messages.ChangesAreSaved);
                table.data = x;
                onChanged(x);
            })
            .catch((ex) => {
                setSaving(false);
                notify.error(ex);
            });
    };

    const onDeleteClick = () => {
        setDeleting(true);
        tableDesignerApi
            .deleteTable(table.name)
            .then((x) => {
                setSaving(false);
                notify.info(messages.RowIsDeleted);
                onChanged(null);
            })
            .catch((ex) => {
                setSaving(false);
                notify.error(ex);
            });
    };

    const defaultPageSize = 10;
    const skipReset = true;

    const updateData = (rowIndex, columnId, value) => {
        //setSkipPageReset(true);
        setData(data.map((row, index) => (index === rowIndex ? { ...data[rowIndex], [columnId]: value } : row)));
    };

    const tableApi = useTable(
        {
            initialState: { pageSize: defaultPageSize },
            defaultColumn: {
                Cell: DefaultEditor,
                minWidth: 30,
                disableGroupBy: true,
                //maxWidth: 200,
            },
            columns: useMemo(
                () => [
                    {
                        Header: "ID",
                        accessor: "id",
                        readOnly: true,
                        width: 50,

                        getDisplayValue: (value) => (value === 1 ? "one" : value),
                    },
                    { Header: "NAME", accessor: "name", display: "text" },
                    {
                        Header: "TITLE",
                        accessor: "title",
                        readonly: (r, c) => r.values.isRequired,
                    },
                    { Header: "IsPK", accessor: "isPK", width: 50, display: "check" },
                    { Header: "Required", accessor: "isRequired", display: "switch", width: 80 },
                    { Header: "DefaultValue", accessor: "defaultValue", width: 100 },

                    { Header: "List", accessor: "showInList", display: "check", width: 50 },
                    { Header: "Editor", accessor: "showInEditor", display: "check", width: 50 },
                    {
                        Header: "Display",
                        accessor: "display",
                        width: 100,
                        display: "select",
                        validValues: ", text, email, url, number, amount, textarea, check, switch, select, shamsi",
                    },
                    { Header: "ValidValues", accessor: "validValues", display: "textarea" },

                    //{ Header: "Expression", accessor: "expression" },
                    // { Header: "Alias", accessor: "alias" },
                    //{ Header: "ToggleOnClick", accessor: "toggleOnClick" },
                    //{ Header: "CellStyle", accessor: "cellStyle" },
                    //{ Header: "CellClassName", accessor: "cellClassName" },
                    //{ Header: "Category", accessor: "category" },

                    {
                        Header: "Dir",
                        accessor: "dir",
                        display: "select",
                        validValues: ",rtl,ltr",
                        width: 70,
                        disableGroupBy: false,
                    },
                ],
                []
            ),
            data: useMemo(() => data, [data]),
            //filterTypes: useMemo(() => reactTable.filterTypes, []),
            updateMyData: updateData,
            autoResetPage: !skipReset,
            autoResetFilters: !skipReset,
            autoResetSortBy: !skipReset,
            autoResetSelectedRows: !skipReset,
            autoResetGlobalFilter: !skipReset,
            disableMultiSort: false,
        },
        useGlobalFilter,
        useFilters,
        useGroupBy,
        useSortBy,
        useExpanded,
        usePagination,
        useRowSelect,
        //useBlockLayout,
        useFlexLayout
        //useResizeColumns
        //(hooks) => reactTable.addSelectionColumns(hooks)
    );

    const moreMenu = (
        <bd.Menu>
            <bd.MenuItem disabled={!table.id || saving || deleting || table.columns.length > 0} onClick={onDeleteClick}>
                {deleting && <div className="m-e-2 spinner-border spinner-border-sm"></div>}
                <span>{t("delete")}</span>
            </bd.MenuItem>
        </bd.Menu>
    );

    const newRow = () => ({ id: 0 });

    return (
        <>
            <div className="border-bottom bg-gray-5 mb-3">
                <div className="container">
                    <bd.Toolbar>
                        <bd.Button variant="icon" onClick={onGoBack} size="md" edge="start" className="m-e-2">
                            <icons.ArrowBackIos className="rtl-rotate-180" />
                        </bd.Button>

                        <h5>{t("edit-table")}</h5>

                        <div className="flex-grow-1" />

                        <bd.Button color="primary" disabled={saving || deleting} onClick={onSaveClick}>
                            {saving && <div className="m-e-2 spinner-border spinner-border-sm"></div>}
                            <span>{t("save-changes")}</span>
                        </bd.Button>

                        <bd.Button variant="icon" menu={moreMenu} edge="end" className="m-s-1">
                            <icons.MoreVert />
                        </bd.Button>
                    </bd.Toolbar>

                    <div className="d-flex">
                        <div className="p-3 rounded-circle bg-shade-10 mx-4 mb-3">
                            <icons.TableView className="size-xl" />
                        </div>
                        <div>
                            <p className="my-2 text-primary-text">{table.name}</p>
                            <p className="m-0 text-secondary-text">
                                {t("created-at")}: {!table.createAt ? "now" : table.createAt}
                            </p>
                        </div>
                    </div>
                    <bd.TabStrip indicatorColor="primary" textColor="primary" className="d-none">
                        <bd.TabStripItem eventKey="t1" href="#info">
                            Table Info{" "}
                        </bd.TabStripItem>
                        <bd.TabStripItem eventKey="t2" href="#columns">
                            Columns
                        </bd.TabStripItem>
                    </bd.TabStrip>
                </div>
            </div>

            <div className="container" style={{ marginBottom: 70 }}>
                <div className="mt-4" style={{ maxWidth: 500 }}>
                    <Formik
                        initialValues={table.data || { name: "", title: "", singularTitle: "" }}
                        validationSchema={yup.object({
                            title: yup.string().min(3, t("msg-too-short")).max(100, t("msg-too-long")).required("Required"),
                        })}
                        onSubmit={onSaveClick}
                        innerRef={formRef}
                    >
                        <form>
                            {insertMode && <BasicInput name="name" label={t("table-designer-table-name")} labelSize="4" autoFocus />}
                            <BasicInput name="title" label={t("table-designer-table-title")} labelSize="4" />
                            <BasicInput name="singularTitle" label={t("table-designer-singular")} labelSize="4" />
                            <BasicTextArea name="description" label={t("description")} labelSize="4" />
                        </form>
                    </Formik>
                </div>

                <TableTitlebar
                    tableApi={tableApi}
                    hideSearch
                    hideSettings
                    title="Columns"
                    fixed
                    buttons={
                        <>
                            <bd.Button
                                variant="icon"
                                size="md"
                                onClick={(e) => {
                                    var r = newRow();
                                    setData([...data, r]);
                                    tableApi.state.selectedRowIds = { [data.length]: true };
                                }}
                            >
                                <icons.Add />
                            </bd.Button>
                            <bd.Button
                                variant="icon"
                                size="md"
                                disabled={!tableApi.selectedFlatRows.length}
                                onClick={(e) => {
                                    const updatedRows = data.filter((x, index) => !tableApi.state.selectedRowIds[index]);
                                    setData(updatedRows);
                                    tableApi.state.selectedRowIds = {};
                                }}
                            >
                                <icons.Delete />
                            </bd.Button>
                        </>
                    }
                />

                <RenderTableDiv
                    tableApi={tableApi}
                    //resizable
                    //multiSelect
                    singleSelect
                    hideCheckbox
                    //hasSummary
                    showTableInfo
                    //showPageSize
                    //enablePaging
                    //enableGrouping
                    enableSorting
                    editable
                    clickAction="select"
                    className="border0 nano-scroll"
                    //style={{ minHeight: 400 }}
                    hover
                    //striped
                    //hasWhitespace
                    //stickyFooter
                />
            </div>
        </>
    );
}
