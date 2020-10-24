import React, {useState, useEffect} from "react";
import ReactDOM from "react-dom";
import {usePortal} from "Hooks";
import "./Modal.scss";

export function Modal(props) {
    const portalEl = usePortal("modal-root");

    function handleCancel(ev) {
        if (!!props.onCancel)
            props.onCancel();
        props.toggle();
    }

    function handleConfirm(ev) {
        if (!!props.onConfirm)
            props.onConfirm();
        props.toggle();
    }

    return ReactDOM.createPortal(
        <div className="modal is-clipped is-active">
            <div className="modal-background"/>
            <div className="modal-card">
                <section className="modal-card-body">
                    <p className="subtitle">{props.text}</p>
                </section>
                <footer className="modal-card-foot">
                    <button className="button is-primary" onClick={(ev) => handleConfirm(ev)}>Yes</button>
                    <button className="button" onClick={(ev) => handleCancel(ev)}>No</button>
                </footer>
            </div>
            <button className="modal-close is-large" aria-label="close" onClick={(ev) => handleCancel(ev)}/>
        </div>, portalEl);
}