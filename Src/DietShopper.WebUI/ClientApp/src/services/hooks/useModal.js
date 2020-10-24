import React, {useState} from "react";
import {Modal} from "components/common";

export function useModal() {
    const [isVisible, setVisible] = useState(false);
    const [modalText, setText] = useState("");
    const [handleConfirm, setHandleConfirm] = useState(() => {});
    const [handleCancel, setHandleCancel] = useState(() => {});

    function toggle() {
        setVisible(prev => !prev);
    }

    function showModal(text, onConfirm, onCancel) {
        setText(text);
        setHandleConfirm(() => onConfirm);
        setHandleCancel(() => onCancel);

        setVisible(true);
    }

    function render() {
        return (
            isVisible
                ? <Modal text={modalText}
                         isVisible={isVisible}
                         onConfirm={handleConfirm}
                         onCancel={handleCancel}
                         toggle={toggle}/>
                : ""
        )
    }

    return {
        render: render,
        showModal: showModal
    };
}