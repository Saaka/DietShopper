import React, {useState, useEffect, useRef} from "react"
import {Loader} from "components/common";
import {Form, TextInput} from "components/forms";
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
                    return err;
                });
        else
            return categoriesService.createProductCategory(category)
                .then(() => setLoading(false))
                .then(clearForm)
                .then(props.onCreated)
                .catch(err => {
                    setError(err.error);
                    setLoading(false);
                    return err;
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

    return (
        <div className="box">
            <div>
                <p className="subtitle">Category</p>
            </div>
            <hr/>
            <Form name="categoryForm" onSubmit={submitCategory} onClose={closeForm} isLoading={isLoading} errorText={error}>
                <TextInput id="category-name"
                           label="Name"
                           name="name"
                           value={category.name}
                           onChange={handleChange}
                           disabled={isLoading}
                           inputRef={nameInput}
                           maxLength="32"
                           required
                           error="Category name is required"/>
            </Form>
        </div>
    );
}

export {CategoryForm};