import React, {useState} from "react";
import {Icon} from "components/common";
import {useModal, QuestionModal, Modal} from "Modal";
import {ProductMeasureFormModal} from "./ProductMeasureFormModal";
import "./ProductMeasures.scss";

const ProductMeasures = (props) => {
    const [productMeasure, setProductMeasure] = useState(null);
    const modal = useModal();

    const onEdit = (ev, measure) => {
        ev.stopPropagation();
        setProductMeasure(measure);
        modal.showModal(new ProductMeasureFormModal(props.setProduct, measure, props.measures));
    }

    const onRemove = (ev, measure) => {
        ev.stopPropagation();
        modal.showModal(new QuestionModal(`Do you want to remove measure "${measure.name}"?`, () => {
            props.setProduct(prod => ({
                ...prod,
                productMeasures: prod.productMeasures.filter(el => el.measureGuid !== measure.measureGuid)
            }));
        }));
    }

    const defaultText = (measure) => measure.isDefault ? " (default)" : "";

    return (
        <div>
            <label className="label">Measures</label>
            <table className="table is-hoverable is-fullwidth measures-table">
                <thead>
                <tr>
                    <td>Name</td>
                    <td>Symbol</td>
                    <td>Value in grams</td>
                    <td/>
                </tr>
                </thead>
                <tbody>
                {props.product.productMeasures.map(measure =>
                    (
                        <tr key={measure.productMeasureGuid} className="measure-row"
                            onClick={(ev) => onEdit(ev, measure)}>
                            <td>{measure.name + defaultText(measure)}</td>
                            <td>{measure.symbol}</td>
                            <td>{measure.valueInGrams}</td>
                            <td className="list-action" onClick={(ev) => onRemove(ev, measure)}><Icon name="ban"/></td>
                        </tr>
                    )
                )}
                </tbody>
            </table>
            {modal.render()}
        </div>
    )
}

export {ProductMeasures};