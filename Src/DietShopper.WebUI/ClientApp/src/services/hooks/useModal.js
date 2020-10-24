import React, {useEffect, useState} from "react";
import {Modal} from "components/common";

export function useModal() {
    const [isVisible, setVisible] = useState(false);

    function toggle() {
        setVisible(prev => !prev);
    }
    
    function render() {
        return (
            isVisible ? <Modal isVisible={isVisible} toggle={toggle} /> : ""
        )
    }

    return {
        modalRender: render,
        isModalVisible: isVisible,
        toggle
    };
}