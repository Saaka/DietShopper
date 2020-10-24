import React, {useState, useEffect} from "react"
import {useDocumentTitle} from "Hooks";
import {CategoryForm} from "./CategoryForm/CategoryForm";
import {CategoriesList} from "./CateoriesList/CategoriesList";
import {ProductCategoriesService} from "./ProductCategoriesService";
import {Loader} from "components/common";
import "./ProductCategories.scss";

function ProductCategories(props) {
    useDocumentTitle("Product categories - Admin page")
    const categoriesService = new ProductCategoriesService();
    const [categories, setCategories] = useState([]);
    const [isLoading, setIsLoading] = useState(true);
    const [ifFormVisible, setFormVisible] = useState(false);
    const [editedCategory, setEdited] = useState(null);

    useEffect(() => {
        loadCategories();
    }, []);

    function loadCategories() {
        setIsLoading(true);
        return categoriesService
            .getProductCategories()
            .then((data) => {
                setCategories(data);
                setIsLoading(false);
            });
    }

    function renderForm() {
        return (
            ifFormVisible ?
                <div className="box">
                    <CategoryForm toEdit={editedCategory}
                                  onClose={() => closeEditForm()}
                                  onSaved={() => loadCategories()}
                                  onUpdated={() => setEdited(null)}/>
                </div>
                : ""
        );
    }
    
    function closeEditForm() {
        setEdited(null);
        setFormVisible(false);
    }

    function displayEditForm(category) {
        setEdited(category);
        setFormVisible(true);
    }

    function renderList() {
        return (
            isLoading
                ? <div className="center"><Loader size="xs" dark/></div>
                : <CategoriesList editedCategory={editedCategory} onEdit={displayEditForm} categories={categories}/>
        );
    }

    return (
        <section className="columns is-centered">
            <div className="column is-responsive">
                <p className="title has-text-light">Products categories</p>
                <div className="columns columns-content">
                    <div className="column is-half">
                        <div className="box">
                            <div className="columns is-mobile subtitle-container">
                                <div className="column">
                                    <p className="subtitle">Categories list</p>
                                </div>
                                <div className="column">
                                    <button className="button is-small add-category"
                                            onClick={() => setFormVisible(true)}>Add category
                                    </button>
                                </div>
                            </div>
                            <hr/>
                            {renderList()}
                        </div>
                    </div>
                    <div className="column is-half">
                        {renderForm()}
                    </div>
                </div>
            </div>
        </section>
    );
}

export {ProductCategories};