import React, {useState, useEffect, useRef} from "react"
import "./CategoryForm.scss";
import {Loader} from "components/common";
import {ProductCategoriesService} from "../ProductCategoriesService";

function CategoryForm(props) {
    const nameInput = useRef(null);
    const [category, setCategory] = useState({name: "", productCategoryGuid: ""});
    const [isLoading, setLoading] = useState(false);
    const [error, setError] = useState("");
    const categoriesService = new ProductCategoriesService();

    useEffect(() => {
        if (!isLoading && isEditing()) {
            setCategory(props.toEdit);
            focusInput();
        }
        return () => {
        };
    }, [props.toEdit]);

    useEffect(() => focusInput(), [isLoading]);

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
        setLoading(true);

        if (isEditing())
            return categoriesService.updateProductCategory(category)
                .then(() => setLoading(false))
                .then(props.onUpdated)
                .catch(err => {
                    setError(err.error);
                    setLoading(false);
                });
        else
            return categoriesService.createProductCategory(category)
                .then(() => setLoading(false))
                .then(clearForm)
                .then(props.onCreated)
                .catch(err => {
                    setError(err.error);
                    setLoading(false);
                });
    }

    const renderError = () => !!error ? <p className="help is-danger">{error}</p> : "";

    const closeForm = (ev) => {
        clearForm(ev);
        props.onClose();
    }

    function getInputClass(field) {
        return "";
    }

    const isEditing = () => !!props.toEdit;

    const focusInput = () => nameInput.current.focus();

    return (
        <div className="box">
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
                               disabled={isLoading}
                               ref={nameInput}
                               required
                               autoComplete="off"
                               className={"input " + getInputClass("categoryName")}/>
                    </div>
                    {renderError()}
                </div>
                <div className="field is-grouped">
                    <div className="control">
                        <button type="submit" className="button is-primary" disabled={isLoading}>Submit</button>
                    </div>
                    <div className="control">
                        <button type="button" onClick={(ev) => closeForm(ev)}
                                className="button"
                                disabled={isLoading}>Close
                        </button>
                    </div>
                    {isLoading ? <Loader size="xs" dark/> : ""}
                </div>
            </form>
        </div>
    );
}

export {CategoryForm};