import React, {useEffect, useRef, useState} from 'react';
import {useDocumentTitle} from "Hooks";
import {Form, Select, TextInput} from "components/forms";
import {useHistory} from "react-router-dom";
import {RouteNames} from "routes/names";
import {ProductsService, ProductCategoriesService} from "Services";
import "./ProductForm.scss";

function ProductForm(props) {
    const nameInput = useRef(null);
    const history = useHistory();
    const productsService = new ProductsService();
    const categoriesService = new ProductCategoriesService();

    const [isNew, setIsNew] = useState(true);
    const [title, setTitle] = useState("Product - Admin page");
    const [subtitle, setSubtitle] = useState("");
    const [isLoading, setLoading] = useState(false);
    const [error, setError] = useState("");
    const [product, setProduct] = useState({productGuid: "", name: "", shortName: "", description: ""});
    const [categories, setCategories] = useState([]);
    useDocumentTitle(title);

    useEffect(() => {
        let productGuid = props.match.params.productGuid;
        setLoading(true);
        if (!!productGuid) {
            loadExistingProduct(productGuid);
        } else {
            initializeNewProduct();
        }
    }, []);

    function loadExistingProduct(productGuid) {
        setIsNew(false);
        setSubtitle("Edit product");
        productsService
            .getProduct(productGuid)
            .then(resp => {
                setProduct(resp);
                setTitle(`${resp.name} - Product - Admin page`);
            })
            .then(categoriesService.getProductCategories)
            .then(resp => {
                setCategories(resp.map(el => ({
                    id: el.productCategoryGuid,
                    name: el.name
                })));
            })
            .then(setLoading(false));
    }

    function initializeNewProduct() {
        setIsNew(true);
        setSubtitle("Create product");
        categoriesService
            .getProductCategories()
            .then(resp => {
                let dict = resp.map(el => ({
                    id: el.productCategoryGuid,
                    name: el.name
                }));
                setCategories(dict);
                return dict
            })
            .then((dict) => updateSelectedCategory(dict[0].id, categories))
            .then(setLoading(false));
    }

    useEffect(() => focusInput(), [isLoading]);

    function submitCategory(ev) {
        ev.preventDefault();
        setError("");
        setLoading(true);

        if (isNew) {
            productsService.createProduct(product)
                .then(closeForm)
                .catch((err) => {
                    setError(err.error);
                    setLoading(false);
                });
        } else {
            productsService.updateProduct(product)
                .then(closeForm)
                .catch((err) => {
                    setError(err.error);
                    setLoading(false);
                });
        }
    }

    function handleChange(ev) {
        const {name, value} = ev.target;
        setProduct(prod => ({...prod, [name]: value}));
    }

    const focusInput = () => nameInput.current.focus();

    const closeForm = () => history.push(RouteNames.AdminProducts);

    const handleCategoryChange = (ev) => {
        const {value} = ev.target;
        updateSelectedCategory(value, categories);
    }

    const updateSelectedCategory = (value, categories) => {
        if (!value || categories.length === 0)
            return;

        setProduct(p => ({...p, productCategoryGuid: value}));
    }

    return (
        <section className="columns is-centered">
            <div className="column is-responsive">
                <p className="title has-text-light">Product</p>
                <div className="box">
                    <p className="subtitle">{subtitle}</p>
                    <hr/>
                    <Form name="productForm" onSubmit={submitCategory} onClose={closeForm} isLoading={isLoading}
                          errorText={error} object={product}>
                        <TextInput id="product-name"
                                   label="Name"
                                   name="name"
                                   value={product.name}
                                   onChange={handleChange}
                                   disabled={isLoading}
                                   inputRef={nameInput}
                                   maxLength="64"
                                   required
                                   error="Product name is required"/>
                        <TextInput id="product-shortName"
                                   label="Short name"
                                   name="shortName"
                                   value={product.shortName}
                                   onChange={handleChange}
                                   disabled={isLoading}
                                   maxLength="16"/>
                        <TextInput id="product-description"
                                   label="Description"
                                   name="description"
                                   value={product.description}
                                   onChange={handleChange}
                                   disabled={isLoading}
                                   maxLength="256"/>
                        <Select id="product-category"
                                label="Product category"
                                name="productCategoryGuid"
                                onChange={handleCategoryChange}
                                values={categories}
                                value={product.productCategoryGuid}
                                required/>
                    </Form>
                </div>
            </div>
        </section>
    )
}

export {ProductForm};