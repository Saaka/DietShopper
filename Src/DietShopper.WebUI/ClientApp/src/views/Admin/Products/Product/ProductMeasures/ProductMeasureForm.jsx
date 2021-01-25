import React, {useState, useEffect} from "react";
import {Modal} from "Modal";
import {TextInput, Checkbox, NumberInput} from "components/forms";

const ProductMeasureForm = (props) => {
    const [measure, setMeasure] = useState({isDefault: false});

    useEffect(() => {
        if (!!props.measure)
            setMeasure(props.measure);
    }, []);

    const getTitle = () => props.measure == null ? "Add product measure" : "Edit product measure";

    const saveChanges = (ev) => {

        props.setProduct(prod =>({
            ...prod,
            productMeasures: prod.productMeasures.map(el => el.measureGuid === measure.measureGuid ? {
                ...el,
                isDefault: measure.isDefault
            } : {
                ...el,
                isDefault: measure.isDefault ? false : el.isDefault
            })
        }));
        props.toggle();
    }

    function handleCheckboxChange(ev) {
        const {name, checked} = ev.target;
        setMeasure(prev => ({...prev, [name]: checked}));
    }

    const buttonGroup = () =>
        <div className="field is-grouped">
            <div className="control">
                <button type="submit" className="button is-primary" onClick={(ev) => saveChanges(ev)}>Save changes
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