import React from "react";
import {Icon} from "components/common";
import "./ProductsList.scss";

export const ProductsList = ({products, onEdit, onRemove}) => {
    
    return (
        <div>
            <table className="table is-hoverable is-fullwidth">
                <thead>
                <tr>
                    <td>Name</td>
                    <td/>
                    <td/>
                </tr>
                </thead>
                <tbody>
                {products.map(product =>
                    (
                        <tr key={product.productGuid}>
                            <td>{product.name}</td>
                            <td className="list-action" onClick={(ev) => onEdit(product)}><Icon name="edit"/></td>
                            <td className="list-action" onClick={(ev) => onRemove(product)}><Icon name="ban"/></td>
                        </tr>
                    )
                )}
                </tbody>
            </table>
        </div>
    );
}