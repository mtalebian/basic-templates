import React from "react";
import classNames from "classnames";
import { Form, Formik } from "formik";

export const FormikForm = ({ initialValues, validationSchema, onSubmit, innerRef, validate, className, flex, compact, children }) => {
    return (
        <Formik
            initialValues={initialValues ?? {}}
            validationSchema={validationSchema}
            onSubmit={onSubmit}
            innerRef={innerRef}
            validate={validate}
        >
            <Form
                className={classNames(className, "bd-form", {
                    "bd-form-flex": flex,
                    "bd-form-compact": compact,
                })}
            >
                {children}
            </Form>
        </Formik>
    );
};
