import React, { useEffect, useState } from "react";
import { Switch, Route } from "react-router-dom";

import { ThemeProvider } from "./app/theme-context";
import accountManager from "./app/account-manager";
import { notify } from "./components/basic/notify";

/*
import BasicLayout from "./components/layout/basic-layout";
import Header from "./views/shared/header";
import Sidebar from "./views/shared/sidebar";

import AccountHeader from "./views/account/account-header";
import AccountFooter from "./views/account/account-footer";
import RegisterForm from "./views/account/register-form";
import LoginForm from "./views/account/login-form";
import ManageUsersForm from "./views/manage/manage-users-form";

import NotFound from "./views/shared/not-found";
import { AzRoute } from "./app/az-route";
import RoleForm from "./views/admin/role-form";



import ManageUsersForm from "./views/manage/manage-users-form";
*/
import { AzRoute } from "./app/az-route";
import { MenuApp } from "./views/admin/menu/menu-app";

import { LoginForm } from "./views/account/login-form";
import NotFound from "./views/shared/not-found";

import { DashboardApp } from "./views/home/dashboard/dashboard-app.js";
import { InboxApp } from "./views/home/inbox/inbox-app";
import { LunchpadApp } from "./views/home/lunchpad/lunchpad-app";
import StartupApp from "./views/home/startup/startup-app";
import { MainLayout } from "./views/shared/main-layout2";

import { TablesApp } from "./views/admin/tables/tables-app";
import { FormDesignerApp } from "./views/admin/form-designer/form-designer-app";
import { TableDesignerApp } from "./views/admin/table-designer/table-designer-app";
import { TestTableApp } from "./views/test/test-table";
import { UserSettingsApp } from "./views/account/user-settings-app";

/*
function Layout({ layout, header, content, sidebar, footer, ...props }) {
    return (
        <BasicLayout
            layout={!layout ? "hmf" : layout}
            breakPoint={breakPoint}
            header={!header ? Header : header}
            content={content}
            sidebar={!sidebar ? Sidebar : sidebar}
            footer={footer}
            rtl={settings.rtl}
            {...props}
        />
    );
}
*/
export function App() {
    const [loginStatus, setLoginStatus] = useState(false);

    useEffect(() => {
        accountManager
            .init()
            .then((x) => {
                notify.info(x);
                return x;
            })
            .catch((ex) => {
                if (ex.name !== "401") notify.error(ex);
            });
    }, []);

    useEffect(() => accountManager.status.onChange((x) => setLoginStatus(x)).remove, [loginStatus]);

    return (
        <ThemeProvider>
            <Switch>
                <Route exact path="/" render={() => <StartupApp />} />

                <Route exact path="/login">
                    <main className="content h-100 middle text-secondary-text">
                        <LoginForm />
                    </main>
                </Route>

                <AzRoute exact path="/user/settings" render={() => <MainLayout component={UserSettingsApp} />} />

                <AzRoute exact path="/admin/menu" render={() => <MainLayout component={MenuApp} />} />

                <AzRoute exact path="/admin/table-designer" render={() => <MainLayout component={TableDesignerApp} />} />

                <AzRoute exact path="/admin/form-designer" render={() => <MainLayout component={FormDesignerApp} />} />

                <AzRoute exact path="/admin/tables" render={() => <MainLayout component={TablesApp} />} />

                <AzRoute exact path="/home" render={() => <MainLayout component={LunchpadApp} />} />

                <AzRoute exact path="/dashboard" render={() => <MainLayout component={DashboardApp} />} />

                <AzRoute exact path="/inbox" render={() => <MainLayout component={InboxApp} />} />

                <Route exact path="/test/table" render={() => <TestTableApp />} />

                <AzRoute render={() => <MainLayout component={NotFound} />} />
            </Switch>
        </ThemeProvider>
    );
}

/*


                <Route exact path="/admin/role" render={() => <Layout content={RoleForm} />} />

                <AzRoute exact path="/manage/users" render={() => <Layout content={ManageUsersForm} />} />

 
                <Route exact path="/account/login"><Layout layout="hmf" className="account account-light" header={AccountHeader} content={LoginForm} footer={AccountFooter} light /></Route>
                <Route exact path="/account/login2"><Layout layout="hmf" className="account account-dark" header={AccountHeader} content={LoginForm} footer={AccountFooter} dark /></Route>
                <Route exact path="/account/login3"><Layout layout="hmf" className="account account-dark with-background-image" header={AccountHeader} content={LoginForm} footer={AccountFooter} dark /></Route>

                <Route exact path="/account/register"><Layout layout="hmf" className="account account-light" header={AccountHeader} content={RegisterForm} footer={AccountFooter} light /></Route>
                <Route exact path="/account/register2"><Layout layout="hmf" className="account account-dark" header={AccountHeader} content={RegisterForm} footer={AccountFooter} dark /></Route>
                <Route exact path="/account/register3"><Layout layout="hmf" className="account account-dark with-background-image" header={AccountHeader} content={RegisterForm} footer={AccountFooter} dark /></Route>



 */