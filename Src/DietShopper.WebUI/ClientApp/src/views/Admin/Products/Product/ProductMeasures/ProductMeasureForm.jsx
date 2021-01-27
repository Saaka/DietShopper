import React, {useState, useEffect} from "react";
import {Modal} from "Modal";
import {Checkbox, NumberInput, Select} from "components/forms";

const ProductMeasureForm = (props) => {
    const [measure, setMeasure] = useState({isDefault: false});
    const [availableMeasures, setAvailableMeasures] = useState([]);
    const [isNew, setIsNew] = useState(true);

    useEffect(() => {
        const measures = props.measures
            .filter(el => !props.product.productMeasures.some(pm => pm.measureGuid === el.measureGuid) || (!!props.measure && props.measure.measureGuid === el.measureGuid))
            .map(el => ({
            ...el,
            id: el.measureGuid
        }));
        if (!!props.measure) {
            setMeasure(props.measure);
            setIsNew(false);
        } else {
            updateSelectedMeasure(measures[0].id, measures);
        }

        setAvailableMeasures(measures);
    }, []);
    
    const getTitle = () => isNew == null ? "Add product measure" : "Edit product measure";

    const saveChanges = (ev) => {

        if (isNew) {
            props.setProduct(prod => ({
                ...prod,
                productMeasures: prod.productMeasures.map(el => ({
                    ...el,
                    isDefault: measure.isDefault ? false : el.isDefault
                })).concat([measure])
            }))
        } else {
            props.setProduct(prod => ({
                ...prod,
                productMeasures: prod.productMeasures.map(el => el.measureGuid === measure.measureGuid ? {
                    ...el,
                    isDefault: measure.isDefault,
                    valueInGrams: measure.valueInGrams
                } : {
                    ...el,
                    isDefault: measure.isDefault ? false : el.isDefault
                })
            }));
        }
        props.toggle();
    }

    const handleNumberChange = (ev) => {
        const {name, value} = ev.target;
        setMeasure(prev => ({...prev, [name]: Number(value)}));
    }

    function handleCheckboxChange(ev) {
        const {name, checked} = ev.target;
        setMeasure(prev => ({...prev, [name]: checked}));
    }

    const handleMeasureChange = (ev) => {
        const {value} = ev.target;
        updateSelectedMeasure(value, availableMeasures);
    }

    const updateSelectedMeasure = (value, measures) => {
        if (!value || measures.length === 0)
            return;

        const selectedMeasure = measures.find(el => el.measureGuid === value);

        setMeasure(p => ({
            ...p,
            measureGuid: value,
            name: selectedMeasure.name,
            symbol: selectedMeasure.symbol,
            isWeight: selectedMeasure.isWeight
        }));
    }

    const buttonGroup = () =>
        <div className="field is-grouped">
            <div className="control">
                <button type="submit" className="button is-link" onClick={(ev) => saveChanges(ev)}>Save changes
                </button>
            </div>
            <div className="control">
                <button type="button" onClick={(ev) => props.toggle()}
                        className="button">Close
                </button>
            </div>
        </div>;

    return (
        <Modal {...props}>
            <div className="box">
                <p className="subtitle">{getTitle()}</p>
                <hr/>
                <label className="label">{measure.name}</label>
                <Select label="Measure"
                        name="measureGuid"
                        onChange={handleMeasureChange}
                        values={availableMeasures}
                        value={measure.measureGuid}
                        disabled={!isNew}
                        required/>
                <NumberInput label="Value in grams"
                             name="valueInGrams"
                             value={measure.valueInGrams}
                             min={0}
                             max={10000}
                             step={0.01}
                             disabled={measure.isWeight}
                             onChange={handleNumberChange}/>
                <Checkbox name="isDefault"
                          value={measure.isDefault}
                          onChange={handleCheckboxChange}
                          label="Is default"/>
                {buttonGroup()}
            </div>
        </Modal>
    )
};

export {ProductMeasureForm};