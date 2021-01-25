import React from "react";
import {Icon} from "components/common";
import "./ProductMeasures.scss";

const ProductMeasures = (props) => {
    
    const onEdit = (ev, measure) => {
        
    }

    const onRemove = (ev, measure) => {

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
                        <tr key={measure.productMeasureGuid} className="measure-row" onClick={(ev) => onEdit(ev, measure)}>
                            <td>{measure.name + defaultText(measure)}</td>
                            <td>{measure.symbol}</td>
                            <td>{measure.valueInGrams}</td>
                            <td className="list-action" onClick={(ev) => onRemove(ev, measure)}><Icon name="ban"/></td>
                        </tr>
                    )
                )}
                </tbody>
            </table>
        </div>
    )
}

export {ProductMeasures};