import React from "react";
import * as bd2 from "./index.js";
import * as bd from "react-basic-design";
import * as icons from "../../assets/icons";
import { FormRow } from "./form-row.jsx";
//import { useField } from "formik";

export function FormikTest() {
    console.log("> FormikTest");
    return (
        <>
            <bd2.FormikForm
                initialValues={{ status: 1, firstName: "Mahdi", lastName: "Talebian", age: 10, comments: "this is textarea" }}
                onSubmit={(values) => alert("submited")}
                dense
                className="pt-3 p-s-3"
            >
                <GeneralTest />
            </bd2.FormikForm>

            <hr />

            <bd2.FormikForm
                initialValues={{ status: 1, firstName: "Mahdi", lastName: "Talebian", age: 10 }}
                onSubmit={(values) => alert("submited")}
                dense
                className="pt-3 p-s-3"
            >
                <DropDownTest />
            </bd2.FormikForm>
        </>
    );
}

const GeneralTest = () => {
    return (
        <>
            <bd2.FormikInput label="First Name" name="firstName" width="12rem" />
            <bd2.FormikInput label="Last Name" name="lastName" width="12rem" />
            <bd2.FormikInput label="Age" name="age" width="5rem" type="number" />
            <bd2.FormikInput
                label="Status"
                name="status"
                width="7rem"
                items={[
                    { id: 1, title: "SINGLE" },
                    { id: 2, title: "MARRIED" },
                ]}
                type="select"
            />
            <bd2.FormikSwitch label="I Agree" name="agree" width="auto" className="p-e-3" dense size="sm" />
            <bd2.FormikToggle label="readOnly" name="remember" width="auto" size="sm" className="p-e-0" dense readOnly />
            <bd2.FormikInput label="type = label" name="firstName" width="9rem" type="label" inputClassName="bg-transparent" />
            <bd2.FormikTextArea label="comments" name="comments" width="12rem" height="5rem" type="label" inputClassName="bg-transparent" />

            <bd2.FormikInput
                type="text"
                label="company"
                name="company"
                width="12rem"
                //menuTitle={<span title="22 more condition exists">+(22)</span>}
                menuTitle={<icons.Filter3 style={{ fontSize: "1rem" }} />}
                buttonTitle={<icons.OpenInNew style={{ fontSize: "1rem" }} />}
                buttonOnClick={() => alert("clicked")}
                items={[
                    { id: 110, title: "one" },
                    { id: 120, title: "two" },
                    { id: 130, title: "three" },
                ]}
                menu={[
                    { id: 10, title: "value 10" },
                    { id: 20, title: "value 20" },
                    { id: 30, title: "value 30" },
                    { id: 40, title: "value 40" },
                    { id: 50, title: "value 50" },
                ].map((x) => (
                    <div
                        key={x.id}
                        className="bd-dropdown-item d-flex "
                        onClick={(e) => {
                            alert(x.id);
                        }}
                    >
                        <span className="flex-grow-1">{x.title}</span>
                        <bd.Button
                            type="button"
                            variant="text"
                            size="sm"
                            color="primary"
                            onClick={(e) => {
                                e.stopPropagation();
                                alert(`close ${x.id}`);
                            }}
                            className="my-n1 m-e-n2"
                        >
                            <icons.Close className="size-sm" />
                        </bd.Button>
                    </div>
                ))}
            />

            <FormRow label="">
                <div>
                    <bd.Button color="primary" type="button">
                        SAVE
                    </bd.Button>
                </div>
            </FormRow>
            <FormRow label="" className="flex-grow-1 text-end">
                <div>
                    <bd.Button variant="outline" color="secondary" type="button">
                        DELETE
                    </bd.Button>
                </div>
            </FormRow>
        </>
    );
};

const DropDownTest = () => {
    return (
        <>
            <bd2.FormikInput
                label="array if {id, title}"
                name="status"
                items={[
                    { id: 1, title: "one" },
                    { id: 2, title: "tow" },
                    { id: 3, title: "three" },
                    { id: 4, title: "four" },
                    { id: 5, title: "five" },
                ]}
                width="12rem"
                type="number"
                menuTitle="+2"
                buttonTitle={<icons.MoreHoriz />}
            />

            <bd2.FormikInput label="array of numbers" name="status" items={[1, 2, 3, 4, 5]} width="12rem" type="number" />
            <bd2.FormikInput label="array of strings" name="status" items={["1", "2", "3", "4"]} width="12rem" />

            <bd2.FormikInput
                label="readOnly"
                name="status"
                items={[
                    { id: 1, title: "one" },
                    { id: 2, title: "tow" },
                    { id: 3, title: "three" },
                ]}
                width="12rem"
                type="number"
                readOnly
            />

            <bd2.FormikInput
                type="label"
                label="type = label"
                name="status"
                items={[
                    { id: 1, title: "one" },
                    { id: 2, title: "tow" },
                    { id: 3, title: "three" },
                ]}
                width="12rem"
            />

            <bd2.FormikInput
                type="select"
                label="type = select"
                name="status"
                items={[
                    { id: 1, title: "one" },
                    { id: 2, title: "tow" },
                    { id: 3, title: "three" },
                ]}
                width="12rem"
            />

            <bd2.FormikInput
                type="select"
                label="type = select & readOnly"
                name="status"
                items={[
                    { id: 1, title: "one" },
                    { id: 2, title: "tow" },
                    { id: 3, title: "three" },
                ]}
                width="12rem"
                readOnly
                trace
            />

            <bd2.FormikInput
                label="type = select & custom menu"
                name="status"
                menuTitle="more"
                menu={[
                    { id: 10, title: "one" },
                    { id: 20, title: "tow" },
                    { id: 30, title: "three" },
                    { id: 40, title: "four" },
                    { id: 50, title: "five" },
                ].map((x) => (
                    <div key={x.id} className="bd-dropdown-item d-flex " onClick={(e) => {}}>
                        <span className="flex-grow-1">{x.title}</span>
                        <icons.Close className="size-sm" />
                    </div>
                ))}
                width="12rem"
                type="select"
            />

            <bd2.FormikInput
                label="type = text & custom menu"
                name="status"
                menuTitle="more"
                menu={[
                    { id: 10, title: "one" },
                    { id: 20, title: "tow" },
                    { id: 30, title: "three" },
                    { id: 40, title: "four" },
                    { id: 50, title: "five" },
                ].map((x) => (
                    <div key={x.id} className="bd-dropdown-item d-flex " onClick={(e) => {}}>
                        <span className="flex-grow-1">{x.title}</span>
                        <icons.Close className="size-sm" />
                    </div>
                ))}
                width="12rem"
            />

            <hr />

            <select className="form-select">
                {[
                    { id: 10, title: "one" },
                    { id: 20, title: "tow" },
                    { id: 30, title: "three" },
                    { id: 40, title: "four" },
                    { id: 50, title: "five" },
                ].map((x) => (
                    <option key={x.id} value={x.id}>
                        {x.title}
                    </option>
                ))}
            </select>
        </>
    );
};
/*
const Test2 = ({ label, ...props }) => {
    return (
        <>
            <MyTextInput label="First Name" name="firstName" type="text" placeholder="Jane" />
            <MyTextInput label="Last Name" name="lastName" type="text" placeholder="Doe" />
            <MyTextInput label="Age" name="age" type="number" />
        </>
    );
};

const MyTextInput = ({ label, ...props }) => {
    const [field, meta] = useField(props);
    if (label === "Age") console.log("- MyTextInput", label);
    return (
        <>
            <label htmlFor={props.id || props.name}>{label}</label>
            <input className="text-input" {...field} {...props} />
            {meta.touched && meta.error ? <div className="error">{meta.error}</div> : null}
        </>
    );
};
*/