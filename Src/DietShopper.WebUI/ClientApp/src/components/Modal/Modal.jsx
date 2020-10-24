import React, {useState, useEffect} from "react";
import ReactDOM from "react-dom";
import {usePortal} from "Hooks";

export function Modal(props) {
    const portalEl = usePortal("modal-root");

    return ReactDOM.createPortal(
        props.children,
        portalEl
    );
}