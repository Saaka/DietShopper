import React, {useState, useEffect, useRef} from "react";
import {Form, TextInput, Checkbox, NumberInput} from "components/forms";
import {Message} from "components/common";
import {Modal} from "Modal";
import {UnitsOfMeasuresService} from "Services";
import "./MeasureForm.scss";

function MeasureForm(props) {
    const service = new UnitsOfMeasuresService();
    const nameInput = useRef(null);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState("");
    const [measure, setMeasure] = useState({
        measureGuid: "",
        name: "",
        symbol: "",
        isWeight: false,
        valueInGrams: 0,
        isBaseline: false
    });

    useEffect(() => {
        if (isEditing()) {
            setMeasure({...props.toEdit, valueInGrams: props.toEdit.valueInGrams ?? 0});
        }
        focusInput();
        setIsLoading(false);
    }, [props.toEdit]);

    useEffect(() => focusInput(), [isLoading]);

    useEffect(() => {
        if (!measure.isWeight && !isLoading)
            setMeasure(prev => ({...prev, valueInGrams: 0}));
    }, [measure.isWeight]);

    function handleChange(ev) {
        const {name, value} = ev.target;
        setMeasure(prev => ({...prev, [name]: value}));
    }

    function handleCheckboxChange(ev) {
        const {name, checked} = ev.target;
        setMeasure(prev => ({...prev, [name]: checked}));
    }

    const handleSubmit = (ev) => {
        ev.preventDefault();
        setIsLoading(true);
        return saveMeasure(measure)
            .then(res => props.onSubmitted(res.data))
            .then(() => props.toggle())
            .catch(err => {
                setIsLoading(false);
                setError(err.error);
                return err;
            });
    }

    const saveMeasure = (measure) => {
        if (isEditing())
            return service.updateMeasure({...measure})

        return service.createMeasure({...measure})
    }
    
    const isEditing = () => !!props.toEdit;

    const focusInput = () => nameInput.current.focus();

    const displayNotEditableInfo = () => measure.isBaseline ? <Message className="is-info is-small">Base measure can't be edited</Message> : "";
    
    const getTitle = () => isEditing() ? "Update measure" : "Create measure";

    return (
        <Modal {...props}>
            <div className="box">
                <p className="subtitle">{getTitle()}</p>
                <hr/>
                <Form name="measureForm" object={measure} onSubmit={(ev) => handleSubmit(ev)} onClose={props.toggle} isLoading={isLoading} disabled={measure.isBaseline} errorText={error}>
                    <TextInput id="measure-name"
                               label="Name"
                               name="name"
                               value={measure.name}
                               onChange={handleChange}
                               disabled={isLoading || measure.isBaseline}
                               maxLength="32"
                               required
                               error="Measure name is required"
                               inputRef={nameInput}/>
                    <TextInput id="measure-symbol"
                               label="Symbol"
                               name="symbol"
                               value={measure.symbol}
                               onChange={handleChange}
                               disabled={isLoading || measure.isBaseline}
                               maxLength="16"
                               required
                               error="Measure symbol is required"/>
                    <Checkbox id="measure-is-weight"
                              name="isWeight"
                              value={measure.isWeight}
                              onChange={handleCheckboxChange}
                              disabled={isLoading || measure.isBaseline}
                              label="Is weight unit"/>
                    <NumberInput id="measure-value-in-grams"
                                 label="Value in grams"
                                 name="valueInGrams"
                                 value={measure.valueInGrams}
                                 onChange={handleChange}
                                 disabled={!measure.isWeight || isLoading || measure.isBaseline}
                                 required={measure.isWeight}
                                 min={0}
                                 max={10000}
                                 step={0.01}
                                 error="Valid value in grams is required"/>
                    {displayNotEditableInfo()}
                </Form>
            </div>
        </Modal>
    );
}

export {MeasureForm};