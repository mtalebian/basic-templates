/*
    columns
            readonly: true
            readonly: (row) => row.values.myField < 10

            editor: 'text'
            editor: 'check'
            editor: 'switch'
*/
import React from "react";
import { useTranslation } from "react-i18next";
import * as bd from "react-basic-design";
import * as icons from "../../assets/icons";
import classNames from "classnames";

//
export function RenderTableDiv({
    tableApi,
    dataLength,
    resizable,
    showColumnFilter,
    enableGrouping,
    enableSorting,
    multiSelect,
    singleSelect,
    hideCheckbox,
    clickAction,
    enablePaging,
    maxDisplayRow,
    editable,
    hasSummary,
    showTableInfo,
    showPageSize,
    className,
    style,
    hover,
    striped,
    hasWhitespace,
    stickyFooter,
}) {
    const { t } = useTranslation();
    const { rows, page, state } = tableApi;
    const enable_responsive = tableApi.headerGroups.length === 1 && tableApi.columns.some((x) => !!x._breakPoint);
    const cn = classNames("bd-table-div", className, {
        "bd-table-hover": hover,
        "bd-table-resizable": resizable,
        "bd-table-striped": striped,
        selectable: clickAction,
        "has-whitespace": hasWhitespace,
        "sticky-footer": stickyFooter,
    });

    let list = enablePaging ? tableApi.page : tableApi.rows;
    if (list.length > maxDisplayRow) list = list.slice(0, maxDisplayRow);

    const messages = {
        showing: "showing-{from}-to-{to}-of-{total}",
        showingFiltered: "showing-{from}-to-{to}-of-{total}-filtered-from-{all}-rows",
        page: "page-{page}-of-{total}",
        gotoPage: "go-to-page",
        firstPage: "first-page",
        prevPage: "previous-page",
        nextPage: "next-page",
        lastPage: "last-page",
    };

    function getTableInfo() {
        var size = enablePaging ? page.length : rows.length;
        var a = rows.length < 1 ? 0 : enablePaging ? state.pageIndex * state.pageSize + 1 : 1;
        var b = rows.length < 1 ? 0 : a + size - 1;
        var s = state.globalFilter || state.filters.length > 0 ? t(messages.showingFiltered) : t(messages.showing);
        return s.replace("{from}", a.toString()).replace("{to}", b.toString()).replace("{total}", rows.length).replace("{all}", dataLength);
    }

    function getSummary(col) {
        var sum = col._summary;
        if (!sum || typeof sum !== "function") return sum;
        return sum(rows, col);
    }
    function getSortByToggleProps(column) {
        return enableSorting ? column.getSortByToggleProps() : {};
    }

    function getHeaderProps(column) {
        const props = column.getHeaderProps();
        let userProps = column._headerProps;
        if (!userProps) userProps = {};
        else if (typeof userProps === "function") userProps = userProps(column);

        const { className, ...remUserProps } = userProps ? userProps : { className: "" };
        const cn = classNames(className, `bd-column-${column.id}`, {
            [`d-none d-${column._breakPoint}-table-cell`]: enable_responsive && column._breakPoint,
        });

        return { ...props, className: cn, ...remUserProps };
    }

    function getCellProps(row, cell) {
        //console.log(cell);
        if (!cell) cell = row.cells[0];
        var props = cell.getCellProps();
        var userProps = cell.column._cellProps;
        if (userProps) {
            if (typeof userProps === "function") userProps = userProps(row, cell);
            props = { ...props, ...userProps };
        }
        //----
        const { className, ...remUserProps } = props ? props : { className: "" };
        const cn = classNames(className, {
            [`d-none d-${cell.column._breakPoint}-table-cell`]: enable_responsive && cell.column._breakPoint,
        });

        return { ...props, ...remUserProps, className: cn, onClick: () => onTdClick(row, cell) };
    }

    const onTdClick = (row, cell) => {
        if (row.isGrouped) return;
        if (cell.column._ignoreToggleOnClick) return;
        if (!singleSelect && !multiSelect) return;
        //console.log(row);
        const is_selected = row.isSelected;
        switch (clickAction) {
            case "select":
                if (is_selected && multiSelect) break;
                if (singleSelect) tableApi.toggleAllRowsSelected(false);
                row.toggleRowSelected();
                break;

            case "toggle":
                if (singleSelect) tableApi.toggleAllRowsSelected(false);
                if (!is_selected || multiSelect) row.toggleRowSelected();
                break;

            default:
                break;
        }
    };

    const isReadonly = (row, cell) => {
        var r = cell.column.readonly;
        if (!r) return false;
        if (typeof r === "function") return r(row, cell);
        return r;
    };

    console.log(">> RenderTable");

    return (
        <div className="bd-table-div-container" style={{ ...style }}>
            <div {...tableApi.getTableProps()} className={cn}>
                <div className="thead">
                    {tableApi.headerGroups.map((headerGroup) => (
                        <div {...headerGroup.getHeaderGroupProps()} className="tr">
                            {!hideCheckbox && multiSelect && (
                                <div className="th selection-column">
                                    <bd.Toggle
                                        size="sm"
                                        color="primary"
                                        labelClassName="m-0"
                                        {...tableApi.getToggleAllRowsSelectedProps()}
                                    />
                                </div>
                            )}
                            {!hideCheckbox && singleSelect && <div className="th selection-column"></div>}
                            {headerGroup.headers.map((column) => (
                                <div {...getHeaderProps(column)} className="th">
                                    <div className="header-label">
                                        <span {...getSortByToggleProps(column)} className="flex-grow-1">
                                            {column.render("Header")}

                                            {enableSorting && column.isSorted ? (
                                                column.isSortedDesc ? (
                                                    <icons.ArrowDownward className="size-sm" />
                                                ) : (
                                                    <icons.ArrowUpward className="size-sm" />
                                                )
                                            ) : (
                                                ""
                                            )}
                                        </span>

                                        {enableGrouping && column.canGroupBy ? (
                                            // If the column can be grouped, let's add a toggle
                                            <span {...column.getGroupByToggleProps()}>
                                                {column.isGrouped ? (
                                                    <icons.Close className="m-e-1 size-sm text-secondary" />
                                                ) : (
                                                    <icons.Functions className="m-e-1 size-sm text-primary" />
                                                )}
                                            </span>
                                        ) : null}
                                    </div>

                                    {showColumnFilter && column.canFilter && <div className="header-filter">{column.render("Filter")}</div>}

                                    {/* Use column.getResizerProps to hook up the events correctly */}
                                    {resizable && (
                                        <div {...column.getResizerProps()} className={`resizer ${column.isResizing ? "isResizing" : ""}`} />
                                    )}
                                </div>
                            ))}
                        </div>
                    ))}
                </div>

                <div {...tableApi.getTableBodyProps()} className="tbody">
                    {list.length === 0 && <div className="nothing-found">{t("nothing-found")}</div>}
                    {list.map((row, rowIndex) => {
                        tableApi.prepareRow(row);
                        return (
                            <div {...row.getRowProps()} className={classNames("tr", { selected: row.isSelected })}>
                                {!hideCheckbox && multiSelect && (
                                    <div className="td selection-column">
                                        <bd.Toggle size="sm" color="primary" labelClassName="m-0" {...row.getToggleRowSelectedProps()} />
                                    </div>
                                )}
                                {!hideCheckbox && singleSelect && (
                                    <div className="td selection-column">
                                        <bd.Toggle
                                            radio
                                            size="sm"
                                            color="primary"
                                            labelClassName="m-0"
                                            {...row.getToggleRowSelectedProps()}
                                            onChange={() => {
                                                tableApi.toggleAllRowsSelected(false);
                                                tableApi.toggleRowSelected(row.id);
                                            }}
                                        />
                                    </div>
                                )}
                                {row.cells.map((cell) => {
                                    return (
                                        <div {...getCellProps(row, cell)} className="td">
                                            {cell.isGrouped ? (
                                                // If it's a grouped cell, add an expander and row count
                                                <>
                                                    <span {...row.getToggleRowExpandedProps()}>
                                                        <icons.ChevronRight
                                                            className={classNames("transition-transform text-primary", {
                                                                "rotate-90": row.isExpanded,
                                                                "rtl-rotate-180": !row.isExpanded,
                                                            })}
                                                        />
                                                    </span>{" "}
                                                    {cell.render("Cell", { editable: false })} ({row.subRows.length})
                                                </>
                                            ) : cell.isAggregated ? (
                                                // If the cell is aggregated, use the Aggregated
                                                // renderer for cell
                                                cell.render("Aggregated")
                                            ) : cell.isPlaceholder ? null : ( // For cells with repeated values, render null
                                                // Otherwise, just render the regular cell
                                                cell.render("Cell", {
                                                    editable: editable && !isReadonly(row, cell) && (!singleSelect || row.isSelected),
                                                })
                                            )}
                                        </div>
                                    );
                                })}
                            </div>
                        );
                    })}
                </div>

                {hasSummary && (
                    <div className="tfoot">
                        <div {...tableApi.footerGroups[0].getFooterGroupProps()} className="tr">
                            {!hideCheckbox && multiSelect && <div className="th selection-column"></div>}
                            {!hideCheckbox && singleSelect && <div className="th selection-column"></div>}
                            {tableApi.footerGroups[0].headers.map((column, idx) => {
                                return (
                                    <div {...column.getFooterProps()} className="th">
                                        <div className="header-label">{getSummary(column)}</div>
                                    </div>
                                );
                            })}
                        </div>
                    </div>
                )}
            </div>

            <div className="bd-table-bottom">
                {showTableInfo && <div className="bd-table-info d-none d-md-block">{getTableInfo()}</div>}

                {enablePaging && showPageSize && (
                    <div className="bd-table-pagination flex-grow-1">
                        <bd.Button
                            variant="icon"
                            size="sm"
                            onClick={() => tableApi.gotoPage(0)}
                            disabled={!tableApi.canPreviousPage}
                            title={messages.firstPage}
                        >
                            <icons.FirstPage className="rtl-rotate-180" />
                        </bd.Button>
                        <bd.Button
                            variant="icon"
                            size="sm"
                            onClick={() => tableApi.previousPage()}
                            disabled={!tableApi.canPreviousPage}
                            title={messages.prevPage}
                        >
                            <icons.ChevronLeft className="rtl-rotate-180" />
                        </bd.Button>
                        <span className="px-2">
                            {messages.page.replace("{page}", state.pageIndex + 1).replace("{total}", tableApi.pageOptions.length)}
                        </span>
                        <bd.Button
                            variant="icon"
                            size="sm"
                            onClick={() => tableApi.nextPage()}
                            disabled={!tableApi.canNextPage}
                            title={messages.nextPage}
                        >
                            <icons.ChevronRight className="rtl-rotate-180 size-md" />
                        </bd.Button>
                        <bd.Button
                            variant="icon"
                            size="sm"
                            onClick={() => tableApi.gotoPage(tableApi.pageCount - 1)}
                            disabled={!tableApi.canNextPage}
                            title={messages.lastPage}
                        >
                            <icons.LastPage className="rtl-rotate-180" />
                        </bd.Button>
                    </div>
                )}
            </div>
        </div>
    );
}