import React, {useState} from "react";
import {Modal} from "components/common";

export function useModal() {
    const [isVisible, setVisible] = useState(false);
    const [modalSettings, setModalSettings] = useState({});

    function toggle() {
        setVisible(prev => !prev);
    }

    function showModal(text, onConfirm, onCancel) {
        setModalSettings({
            modalText: text,
            handleConfirm: onConfirm,
            handleCancel: onCancel
        });

        setVisible(true);
    }

    function render() {
        return (
            isVisible
                ? <Modal toggle={toggle}
                         text={modalSettings.modalText}
                         onConfirm={modalSettings.handleConfirm}
                         onCancel={modalSettings.handleCancel}
                />
                : ""
        )
    }

    return {
        render: render,
        showModal: showModal
    };
}