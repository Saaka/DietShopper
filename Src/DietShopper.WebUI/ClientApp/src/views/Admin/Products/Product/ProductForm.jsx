import React, {useEffect, useRef, useState} from 'react';
import {useDocumentTitle} from "Hooks";
import {Form, Select, TextInput, NumberInput} from "components/forms";
import {ProductMeasures} from "./ProductMeasures/ProductMeasures";
import {useHistory} from "react-router-dom";
import {RouteNames} from "routes/names";
import {ProductsService, ProductCategoriesService, UnitsOfMeasuresService} from "Services";
import "./ProductForm.scss";

function ProductForm(props) {
    const nameInput = useRef(null);
    const history = useHistory();
    const productsService = new ProductsService();
    const categoriesService = new ProductCategoriesService();
    const measuresService = new UnitsOfMeasuresService();

    const [isNew, setIsNew] = useState(true);
    const [title, setTitle] = useState("Product - Admin page");
    const [subtitle, setSubtitle] = useState("");
    const [isLoading, setLoading] = useState(false);
    const [error, setError] = useState("");
    const [product, setProduct] = useState({
        productGuid: "",
        name: "",
        shortName: "",
        description: "",
        calories: 0,
        carbohydrates: 0,
        proteins: 0,
        fat: 0,
        saturatedFat: 0
    });
    const [categories, setCategories] = useState([]);
    const [measures, setMeasures] = useState([]);
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
            .then(onCategoriesLoaded)
            .then(loadMeasures)
            .then(setLoading(false));
    }

    function initializeNewProduct() {
        setIsNew(true);
        setSubtitle("Create product");
        categoriesService
            .getProductCategories()
            .then(onCategoriesLoaded)
            .then((dict) => updateSelectedCategory(dict[0].id, dict))
            .then(loadMeasures)
            .then(setLoading(false));
    }

    const onCategoriesLoaded = (response) => {
        let dict = response.map(el => ({
            id: el.productCategoryGuid,
            name: el.name
        }));
        setCategories(dict);
        return dict
    }

    const loadMeasures = () => {
        return measuresService.getMeasures()
            .then(resp => setMeasures(resp));
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

    function handleNumberChange(ev) {
        const {name, value} = ev.target;
        setProduct(prod => ({...prod, [name]: Number(value)}));
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
                        <Select id="product-category"
                                label="Product category"
                                name="productCategoryGuid"
                                onChange={handleCategoryChange}
                                disabled={isLoading}
                                values={categories}
                                value={product.productCategoryGuid}
                                required/>
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
                        <NumberInput id="calories"
                                     label="Energy value (kcal)"
                                     name="calories"
                                     value={product.calories}
                                     onChange={handleNumberChange}
                                     disabled={isLoading}
                                     min={0}
                                     max={5000}
                                     step={1}
                                     error="Calories value is invalid"/>
                        <NumberInput id="carbohydrates"
                                     label="Carbohydrates"
                                     name="carbohydrates"
                                     value={product.carbohydrates}
                                     onChange={handleNumberChange}
                                     disabled={isLoading}
                                     min={0}
                                     max={100}
                                     step={0.1}
                                     error="Carbohydrates value is invalid"/>
                        <NumberInput id="proteins"
                                     label="Proteins"
                                     name="proteins"
                                     value={product.proteins}
                                     onChange={handleNumberChange}
                                     disabled={isLoading}
                                     min={0}
                                     max={100}
                                     step={0.1}
                                     error="Proteins value is invalid"/>
                        <NumberInput id="fat"
                                     label="Fat"
                                     name="fat"
                                     value={product.fat}
                                     onChange={handleNumberChange}
                                     disabled={isLoading}
                                     min={0}
                                     max={100}
                                     step={0.1}
                                     error="Fat value is invalid"/>
                        <NumberInput id="saturated-fat"
                                     label="Saturated fat"
                                     name="saturatedFat"
                                     value={product.saturatedFat}
                                     onChange={handleNumberChange}
                                     disabled={isLoading}
                                     min={0}
                                     max={product.fat}
                                     step={0.1}
                                     error="Saturated fat value is invalid"/>
                        <ProductMeasures product={product} />
                    </Form>
                </div>
            </div>
        </section>
    )
}

export {ProductForm};