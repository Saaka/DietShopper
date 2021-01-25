import React from "react";
import {ModalBase} from "components/modal";
import {ProductMeasureForm} from "./ProductMeasureForm";

export class ProductMeasureFormModal extends ModalBase {
    constructor(product, setProduct, measures, measure) {
        super();

        this.buildModal = (toggle) => <ProductMeasureForm product={product} setProduct={setProduct} measure={measure} measures={measures} toggle={toggle}/>;
    }
}