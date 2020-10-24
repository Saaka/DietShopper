import React, {useState, useEffect} from "react"
import "./CategoryForm.scss";

function CategoryForm(props) {
    const [category, setCategory] = useState({name: "", productCategoryGuid: ""});

    function handleChange(ev) {
        const {name, value} = ev.target;
        setCategory(cat => ({...cat, [name]: value}));
    }

    function clearForm() {
        setCategory(cat => ({...cat, name: "", productCategoryGuid: ""}));
    }

    function submitCategory(ev) {
        ev.preventDefault();
        alert(category.name);
        clearForm();
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