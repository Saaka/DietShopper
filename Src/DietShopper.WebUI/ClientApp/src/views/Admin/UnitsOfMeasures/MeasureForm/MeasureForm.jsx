import React, {useState, useEffect, useRef} from "react";
import {Form, TextInput} from "components/forms";
import {Modal} from "Modal";
import "./MeasureForm.scss";

function MeasureForm(props) {
    const nameInput = useRef(null);
    const [isLoading, setIsLoading] = useState(false);
    const [measure, setMeasure] = useState({
        measureGuid: "",
        name: "",
    });

    useEffect(() => {
        if (!!props.toEdit)
            setMeasure(props.toEdit);
        focusInput();
    }, []);

    function handleChange(ev) {
        const {name, value} = ev.target;
        setMeasure(prev => ({...prev, [name]: value}));
    }
    
    const handleSubmit = (ev) => {
        ev.preventDefault();
        props.onSubmit(measure);
    }

    const focusInput = () => nameInput.current.focus();

    return (
        <Modal {...props}>
            <div className="box">
                <p className="subtitle">Categories list</p>
                <hr/>
                <Form name="measureForm" object={measure} onSubmit={(ev) => handleSubmit(ev)} onClose={props.toggle}>
                    <TextInput id="measure-name"
                               label="Name"
                               name="name"
                               value={measure.name}
                               onChange={handleChange}
                               disabled={isLoading}
                               inputRef={nameInput}
                               maxLength="32"
                               required
                               error="Measure name is required"/>
                </Form>
            </div>
        </Modal>
    );
}

export {MeasureForm};