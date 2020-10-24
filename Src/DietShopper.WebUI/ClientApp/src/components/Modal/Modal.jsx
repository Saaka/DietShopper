import React, {useState, useEffect} from "react";
import ReactDOM from "react-dom";
import {usePortal} from "Hooks";

export function Modal(props) {
    const portalEl = usePortal("modal-root");

    return ReactDOM.createPortal(
            <div className="modal is-clipped is-active">
                <div className="modal-background"/>
                <div className="modal-card">
                    <section className="modal-card-body">
                        <p className="subtitle">Question</p>
                    </section>
                    <footer className="modal-card-foot">
                        <button className="button is-primary">Yes</button>
                        <button className="button" onClick={props.toggle}>No</button>
                    </footer>
                </div>
                <button className="modal-close is-large" aria-label="close" onClick={props.toggle}/>
            </div>, portalEl);
}