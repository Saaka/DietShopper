import React, {useEffect, useState} from "react"
import {useDocumentTitle} from "Hooks";
import {ProductsList} from "./ProductsList/ProductsList";
import {useHistory} from "react-router-dom";
import "./Products.scss";
import {ProductsService} from "Services";
import {RouteNames} from "routes/names";

function Products(props) {
    const history = useHistory();
    useDocumentTitle("Products - Admin page");
    const productsService = new ProductsService();
    const [productsList, setProducts] = useState({
        items: []
    });
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        setIsLoading(true);
        loadProducts(10, 1)
            .then(() => setIsLoading(false));
    }, []);

    function loadProducts(pageSize, pageNumber) {
        return productsService
            .getProducts({
                pageSize: pageSize,
                pageNumber: pageNumber
            })
            .then((data) => {
                setProducts(data);
            });
    }

    const addProduct = () => {
        history.push(RouteNames.AdminProductCreate);
    }

    const editProduct = (ev, product) => {
        ev.stopPropagation();
        history.push(RouteNames.AdminProductEdit + product.productGuid);
    }

    const removeProduct = (ev, product) => {
        ev.stopPropagation();
    }

    return (
        <section className="columns is-centered">
            <div className="column is-responsive">
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
                    <ProductsList isLoading={isLoading} 
                                  setIsLoading={setIsLoading}
                                  products={productsList.items} 
                                  pageOptions={productsList.options}
                                  onEdit={editProduct} 
                                  onRemove={removeProduct} 
                                  fetch={loadProducts}/>
                </div>
            </div>
        </section>
    );
}

export {Products};