import React, {useState, useEffect} from "react"
import {useDocumentTitle} from "Hooks";
import {useModal, QuestionModal} from "Modal";
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
    const [isFormVisible, setFormVisible] = useState(false);
    const [editedCategory, setEdited] = useState(null);
    const modal = useModal();

    useEffect(() => {
        setIsLoading(true);
        loadCategories()
            .then(() => setIsLoading(false));
    }, []);

    function loadCategories() {
        return categoriesService
            .getProductCategories()
            .then((data) => {
                setCategories(data);
            });
    }

    const renderForm = () => isFormVisible
        ? <CategoryForm toEdit={editedCategory} onClose={closeEditForm} onCreated={handleCategoryCreated} onUpdated={handleCategoryUpdate}/>
        : "";

    function handleCategoryUpdate() {
        setIsLoading(true);
        closeEditForm();
        return loadCategories()
            .then(() => setIsLoading(false));
    }

    function handleCategoryCreated() {
        setIsLoading(true);
        return loadCategories()
            .then(() => setIsLoading(false));
    }

    function closeEditForm() {
        setEdited(null);
        setFormVisible(false);
    }

    function displayEditForm(category) {
        setEdited(category);
        setFormVisible(true);
    }

    function deleteCategory(category) {
        modal.showModal(new QuestionModal(`Do you want to remove product category "${category.name}"?`, () => {
            setIsLoading(true);
            return categoriesService
                .removeProductCategory(category.productCategoryGuid)
                .then(loadCategories)
                .then(() => setIsLoading(false));
        }));
    }

    function renderList() {
        return (
            isLoading
                ? <div className="center"><Loader size="xs" dark/></div>
                : <CategoriesList categories={categories}
                                  selectedCategory={editedCategory}
                                  onEdit={displayEditForm}
                                  onDelete={deleteCategory}/>
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
            {modal.render()}
        </section>
    );
}

export {ProductCategories};