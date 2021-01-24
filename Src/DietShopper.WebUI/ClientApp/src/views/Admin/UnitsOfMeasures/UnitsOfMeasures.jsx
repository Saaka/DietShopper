import React, {useState, useEffect} from "react"
import {useDocumentTitle} from "Hooks";
import {useModal, QuestionModal} from "Modal";
import {Loader} from "components/common";
import {MeasuresList} from "./MeasuresList/MeasuresList";
import {MeasureFormModal} from "./MeasureForm/MeasureFormModal";
import {UnitsOfMeasuresService} from "Services";
import "./UnitsOfMeasures.scss";

function UnitsOfMeasures(props) {
    useDocumentTitle("Units of measures - Admin page")
    const modal = useModal();
    const measuresService = new UnitsOfMeasuresService();
    const [measures, setMeasures] = useState([]);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        setIsLoading(true);
        loadMeasures()
            .then(() => setIsLoading(false));
    }, []);

    function loadMeasures() {
        return measuresService
            .getMeasures()
            .then((data) => {
                setMeasures(data);
            });
    }

    const handleMeasureSaved = (measure) => {
        setIsLoading(true);
        loadMeasures()
            .then(() => setIsLoading(false));
    };

    const addMeasure = () => modal.showModal(new MeasureFormModal(handleMeasureSaved));

    const editMeasure = (measure) => modal.showModal(new MeasureFormModal(handleMeasureSaved, measure));

    const removeMeasure = (measure) => {
        modal.showModal(new QuestionModal(`Do you want to remove measure "${measure.name}"?`, () => {
            setIsLoading(true);
            return measuresService
                .removeMeasure(measure.measureGuid)
                .then(() => loadMeasures())
                .then(() => setIsLoading(false));
        }));
    }

    function renderList() {
        return (
            isLoading
                ? <div className="center"><Loader size="xs" dark/></div>
                : <MeasuresList measures={measures} onEdit={editMeasure} onRemove={removeMeasure}/>
        );
    }

    return (
        <section className="columns is-centered">
            <div className="column is-responsive">
                <p className="title has-text-light">Units of measures</p>
                <div className="box">
                    <div className="columns is-mobile subtitle-container">
                        <div className="column">
                            <p className="subtitle">Measures list</p>
                        </div>
                        <div className="column">
                            <button className="button is-small add-category"
                                    onClick={() => addMeasure()}>Add measure
                            </button>
                        </div>
                    </div>
                    <hr/>
                    {renderList()}
                </div>
            </div>
            {modal.render()}
        </section>
    );
}

export {UnitsOfMeasures};