import React from "react";
import {Icon} from "components/common";
import "./Checkbox.scss";

export function Checkbox(props) {

    const icon = () => props.value ? <Icon name="check-square" size="lg"/> : <Icon name="square" size="lg"/>;
    
    return (
        <div className="field">
            <label>
                <input type="checkbox"
                       id={props.is}
                       name={props.name}
                       checked={props.value}
                       onChange={props.onChange}
                       className="hidden-checkbox" />
                {icon()} {props.label}
            </label>
        </div>
    );
}