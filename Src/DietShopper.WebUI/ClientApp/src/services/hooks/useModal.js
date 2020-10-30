import React, {useState} from "react";
import {ModalProps} from "components/modal";

export function useModal() {
    const [isVisible, setVisible] = useState(false);
    const [modalProps, setModalProps] = useState({});

    function toggle() {
        setVisible(prev => !prev);
    }

    function showModal(props) {
        setModalProps(props);

        setVisible(true);
    }

    function render() {
        return (
            isVisible
                ? modalProps.buildModal(toggle)
                : ""
        )
    }

    return {
        render: render,
        showModal: showModal
    };
}