import React, {useState, useEffect, useRef} from "react";
import {Form, TextInput, Checkbox, NumberInput} from "components/forms";
import {Message} from "components/common";
import {Modal} from "Modal";
import "./MeasureForm.scss";

function MeasureForm(props) {
    const nameInput = useRef(null);
    const [isLoading, setIsLoading] = useState(true);
    const [measure, setMeasure] = useState({
        measureGuid: "",
        name: "",
        symbol: "",
        isWeight: false,
        valueInGrams: "",
        isBaseline: false
    });

    useEffect(() => {
        if (!!props.toEdit)
            setMeasure(props.toEdit);

        focusInput();
        setIsLoading(false);
    }, [props.toEdit]);

    useEffect(() => focusInput(), [isLoading]);

    useEffect(() => {
        if (!measure.isWeight && !isLoading)
            setMeasure(prev => ({...prev, valueInGrams: ""}));
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
        props.onSubmitted(measure);

        setTimeout(() => {
            setIsLoading(false);
        }, 300);
    }

    const focusInput = () => nameInput.current.focus();

    const displayNotEditableInfo = () => measure.isBaseline ? <Message className="is-info is-small">Base measure can't be edited</Message> : "";

    return (
        <Modal {...props}>
            <div className="box">
                <p className="subtitle">Categories list</p>
                <hr/>
                <Form name="measureForm" object={measure} onSubmit={(ev) => handleSubmit(ev)} onClose={props.toggle} isLoading={isLoading} disabled={measure.isBaseline}>
                    <TextInput id="measure-name"
                               label="Name"
                               name="name"
                               value={measure.name}
                               onChange={handleChange}
                               disabled={isLoading}
                               maxLength="32"
                               required
                               error="Measure name is required"
                               inputRef={nameInput}/>
                    <TextInput id="measure-symbol"
                               label="Symbol"
                               name="symbol"
                               value={measure.symbol}
                               onChange={handleChange}
                               disabled={isLoading}
                               maxLength="16"
                               required
                               error="Measure symbol is required"/>
                    <Checkbox id="measure-is-weight"
                              name="isWeight"
                              value={measure.isWeight}
                              onChange={handleCheckboxChange}
                              disabled={isLoading}
                              label="Is weight unit"/>
                    <NumberInput id="measure-value-in-grams"
                                 label="Value in grams"
                                 name="valueInGrams"
                                 value={measure.valueInGrams}
                                 onChange={handleChange}
                                 disabled={!measure.isWeight || isLoading}
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