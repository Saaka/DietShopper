import React, {useState} from "react";
import {Loader} from "components/common";
import "./Form.scss";

export function Form(props) {
    const [isSubmitted, setIsSubmitted] = useState(false);
    
    const handleSubmit = (ev) => {
        setIsSubmitted(true);
        return props.onSubmit(ev);
    };
    
    const getFormClass = () => isSubmitted ? "is-validated" : "";

    const loader = () => props.isLoading ? <Loader size="xs" dark/> : "";

    const buttonGroup = () =>
        <div className="field is-grouped">
            <div className="control">
                <button type="submit" className="button is-primary" disabled={props.isLoading}>Submit</button>
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
        <form name={props.name} noValidate onSubmit={(ev) => handleSubmit(ev)} className={getFormClass()}>
            {props.children}
            {buttonGroup()}
            {formError()}
        </form>
    );
}