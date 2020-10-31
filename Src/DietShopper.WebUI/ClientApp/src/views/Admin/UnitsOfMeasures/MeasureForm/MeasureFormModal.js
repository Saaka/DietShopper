import React from "react";
import {ModalBase} from "components/modal";
import {MeasureForm} from "./MeasureForm";

export class MeasureFormModal extends ModalBase {
    constructor(onSubmitted, measure) {
        super();
        
        this.buildModal = (toggle) => <MeasureForm onSubmitted={onSubmitted} toEdit={measure} toggle={toggle}/>;
    }
}