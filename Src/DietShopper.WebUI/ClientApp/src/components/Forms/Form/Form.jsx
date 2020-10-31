import React, {useState, useEffect} from "react";
import {Loader} from "components/common";
import "./Form.scss";

export function Form(props) {
    
    const handleSubmit = (ev) => {
        props.object._isSubmitted_ = true;
        return props.onSubmit(ev);
    };

    const getFormClass = () => props.object._isSubmitted_ ? "is-validated" : "";

    const loader = () => props.isLoading ? <Loader size="xs" dark/> : "";

    const buttonGroup = () =>
        <div className="field is-grouped">
            <div className="control">
                <button type="submit" className="button is-primary" disabled={props.isLoading || props.disabled}>Submit</button>
            </div>
            <div className="control">
                <button type="button" onClick={(ev) => props.onClose(ev)}
                        className="button"
                        disabled={props.isLoading}>Close
                </button>
            </div>
            {loader()}
        </div>;

    const formError = () => !!props.errorText ?
        <article className="message is-danger is-small">
            <div className="message-body">
                {props.errorText}
            </div>
        </article>
        : "";

    return (
        <form name={props.name} noValidate onSubmit={(ev) => handleSubmit(ev)} className={getFormClass()} >
            {props.children}
            <div>
                <hr />
            </div>
            {buttonGroup()}
            {formError()}
        </form>
    );
}