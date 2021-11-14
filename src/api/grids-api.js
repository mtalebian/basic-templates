import settings from "../app/settings";
import { api } from "./api";
import { apiConfig } from "./config";

export const gridsApi = {
    getGroups: () => api.call("post", `${apiConfig.gridsUrl}/get-groups?projectId=${settings.projectId}`),

    browseGrid: (id, filters) => api.call("post", `${apiConfig.gridsUrl}/browse-grid?projectId=${settings.projectId}&id=${id}`, filters),

    getGrid: (id) => {
        return api.call("post", `${apiConfig.gridsUrl}/get-grid?projectId=${settings.projectId}&id=${id}`, null);
    },

    getGridData: (id, filters, parameters) => {
        var dto = { filters, parameters };
        return api.call("post", `${apiConfig.gridsUrl}/get-grid-data?projectId=${settings.projectId}&id=${id}`, dto);
    },

    save: (gridId, values, insertMode) => {
        var dto = { action: insertMode ? "insert" : "update", gridId, values };
        return api.call("post", `${apiConfig.gridsUrl}/exec-grid-action?projectId=${settings.projectId}`, dto);
    },

    delete: (gridId, values) => {
        var dto = { action: "delete", gridId, values };
        return api.call("post", `${apiConfig.gridsUrl}/exec-grid-action?projectId=${settings.projectId}`, dto);
    },

    saveVaraint: (gridId, variant) => {
        return api.call("post", `${apiConfig.gridsUrl}/grid-variant-save?projectId=${settings.projectId}&gridId=${gridId}`, variant);
    },

    updateVaraints: (gridId, variants) => {
        var dto = variants.map((x) => ({
            serial: x.serial,
            title: x.title,
            isDefault: x.isDefault,
            isPublic: x.isPublic,
            autoApply: x.autoApply,
        }));
        return api.call("post", `${apiConfig.gridsUrl}/grid-variants-update?projectId=${settings.projectId}&gridId=${gridId}`, dto);
    },

    deleteVariant: (serial) => {
        return api.call("post", `${apiConfig.gridsUrl}/grid-variant-delete?serial=${serial}`, null);
    },
};
