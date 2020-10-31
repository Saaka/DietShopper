import React from "react";
import {ModalBase} from "components/modal";
import {MeasureForm} from "./MeasureForm";

export class MeasureFormModal extends ModalBase {
    constructor(onSubmit, measure) {
        super();
        
        this.buildModal = (toggle) => <MeasureForm onSubmit={onSubmit} toEdit={measure} toggle={toggle}/>;
    }
}