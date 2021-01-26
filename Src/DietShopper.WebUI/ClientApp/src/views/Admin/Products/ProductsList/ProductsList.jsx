import React from "react";
import {Icon, Loader} from "components/common";
import {Pagination} from "components/navigation";
import "./ProductsList.scss";

export const ProductsList = ({products, pageOptions, onEdit, onRemove, fetch, isLoading, setIsLoading}) => {

    const renderLoader = () => <div className="center"><Loader size="xs" dark/></div>;

    const renderTable = () => (
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
    );

    return (
        <div>
            {isLoading ? renderLoader() : renderTable()}
            <Pagination options={pageOptions} fetch={fetch} isLoading={isLoading} setIsLoading={setIsLoading}/>
        </div>
    );
}