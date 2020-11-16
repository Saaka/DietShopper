import React, {useState} from "react"
import {useDocumentTitle} from "Hooks";
import {Loader} from "components/common";
import {ProductsList} from "./ProductsList/ProductsList";
import "./Products.scss";

function Products(props) {
    useDocumentTitle("Products - Admin page");
    const [products, setProducts] = useState([]);
    const [isLoading, setIsLoading] = useState(true);

    const addProduct = () => {

    }

    const editProduct = () => {

    }

    const removeProduct = () => {

    }

   const renderList =() => {
        return(
            isLoading
                ? <div className="center"><Loader size="xs" dark/></div>
                : <ProductsList products={products} onEdit={editProduct} onRemove={removeProduct}/>
        );
    }

    return (
        <section className="columns is-centered">
            <div className="column is-half-desktop">
                <p className="title has-text-light">Products</p>
                <div className="box">
                    <div className="columns is-mobile subtitle-container">
                        <div className="column">
                            <p className="subtitle">Products list</p>
                        </div>
                        <div className="column">
                            <button className="button is-small add-category"
                                    onClick={() => addProduct()}>Add product
                            </button>
                        </div>
                    </div>
                    <hr/>
                    {renderList()}
                </div>
            </div>
        </section>
    );
}

export {Products};