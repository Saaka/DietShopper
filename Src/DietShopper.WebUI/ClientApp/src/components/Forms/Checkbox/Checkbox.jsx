import React from "react";
import {Icon} from "components/common";
import "./Checkbox.scss";

export function Checkbox(props) {

    return (
        <div className="field">
            <label>
                <input type="checkbox"
                       id={props.is}
                       name={props.name}
                       checked={props.value}
                       onChange={props.onChange}
                       className="hidden-checkbox" />
                {props.label} {" " + props.value}
            </label>
        </div>
    );
}