import React from "react";
import {QuestionModalComponent, ModalProps} from "components/modal";

export class QuestionModal extends ModalProps {
    constructor(text, onConfirm, onClose) {
        super(onClose);
        
        this.buildModal = (toggle) => <QuestionModalComponent text={text} onConfirm={onConfirm} onClose={onClose} toggle={toggle}/>;
    }
}