import React from "react";
import {ModalBase} from "components/modal";
import {ProductMeasureForm} from "./ProductMeasureForm";

export class ProductMeasureFormModal extends ModalBase {
    constructor(setProduct, measure, measures) {
        super();

        this.buildModal = (toggle) => <ProductMeasureForm setProduct={setProduct} measure={measure} measures={measures} toggle={toggle}/>;
    }
}