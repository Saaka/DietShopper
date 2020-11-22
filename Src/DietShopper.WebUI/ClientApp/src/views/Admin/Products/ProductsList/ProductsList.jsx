import React from "react";
import {Icon} from "components/common";
import "./ProductsList.scss";

export const ProductsList = ({products, onEdit, onRemove}) => {
    
    const test = (ev, message) => {
        
        console.log(ev);
        console.log(message);
    }
    
    return (
        <div>
            <table className="table is-hoverable is-fullwidth products-table">
                <thead>
                <tr>
                    <td>Name</td>
                    <td/>
                </tr>
                </thead>
                <tbody>
                {products.map(product =>
                    (
                        <tr key={product.productGuid} className="product-row" onClick={(ev) => onEdit(ev, product)}>
                            <td>{product.name}</td>
                            <td className="list-action" onClick={(ev) => onRemove(ev, product)}><Icon name="ban"/></td>
                        </tr>
                    )
                )}
                </tbody>
            </table>
        </div>
    );
}