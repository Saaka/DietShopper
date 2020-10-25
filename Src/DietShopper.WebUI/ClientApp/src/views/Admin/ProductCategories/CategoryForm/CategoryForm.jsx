import React, {useState, useEffect, useRef} from "react"
import {Loader} from "components/common";
import {Form} from "components/forms";
import {ProductCategoriesService} from "../ProductCategoriesService";
import "./CategoryForm.scss";

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
    }, [props.toEdit]);

    useEffect(() => focusInput(), [isLoading]);

    function handleChange(ev) {
        const {name, value} = ev.target;
        setCategory(cat => ({...cat, [name]: value}));
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

    function getInputClass(field) {
        //TODO Validation
        return "";
    }

    const closeForm = (ev) => props.onClose();

    const clearForm = () => setCategory(cat => ({...cat, name: "", productCategoryGuid: ""}));

    const isEditing = () => !!props.toEdit;

    const focusInput = () => nameInput.current.focus();

    const renderLoader = () => isLoading ? <Loader size="xs" dark/> : "";

    const renderError = () => !!error ? <p className="help is-danger">{error}</p> : "";

    const renderFormError = () => !!error ?
        <article className="message is-danger is-small">
            <div className="message-body">
                {error}
            </div>
        </article> : "";

    return (
        <div className="box">
            <div>
                <p className="subtitle">Category</p>
            </div>
            <hr/>
            <Form name="categoryForm" onSubmit={submitCategory} onClose={closeForm} isLoading={isLoading} errorText={error}>
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
            </Form>
        </div>
    );
}

export {CategoryForm};