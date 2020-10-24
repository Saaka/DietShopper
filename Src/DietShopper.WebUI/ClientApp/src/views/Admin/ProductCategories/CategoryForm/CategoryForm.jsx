import React, {useState, useEffect} from "react"
import "./CategoryForm.scss";
import {ProductCategoriesService} from "../ProductCategoriesService";

function CategoryForm(props) {
    const [category, setCategory] = useState({name: "", productCategoryGuid: ""});
    const [error, setError] = useState("");
    const categoriesService = new ProductCategoriesService();

    function handleChange(ev) {
        const {name, value} = ev.target;
        setCategory(cat => ({...cat, [name]: value}));
    }

    function clearForm() {
        setCategory(cat => ({...cat, name: "", productCategoryGuid: ""}));
    }

    function submitCategory(ev) {
        ev.preventDefault();
        setError("");
        categoriesService.createProductCategory(category)
            .then(props.onCreated)
            .then(clearForm)
            .catch(err => setError(err.error));
    }

    function renderError() {
        return (
            !!error
                ? <p className="help is-danger">{error}</p>
                : ""
        );
    }

    function closeForm(ev) {
        clearForm(ev);
        props.onClose();
    }

    function getInputClass(field) {
        return "";
    }

    return (
        <div>
            <div>
                <p className="subtitle">Category</p>
            </div>
            <hr/>
            <form name="categoryForm" onSubmit={(ev) => submitCategory(ev)} noValidate>
                <div className="field">
                    <label className="label">Name</label>
                    <div className="control">
                        <input type="text"
                               id="category-name"
                               name="name"
                               value={category.name}
                               onChange={handleChange}
                               className={"input " + getInputClass("categoryName")}/>
                    </div>
                    {renderError()}
                </div>
                <div className="field is-grouped">
                    <div className="control">
                        <button type="submit" className="button is-primary">Submit</button>
                    </div>
                    <div className="control">
                        <button type="button" onClick={(ev) => closeForm(ev)}
                                className="button is-link is-light">Close
                        </button>
                    </div>
                </div>
            </form>
        </div>
    );
}

export {CategoryForm};