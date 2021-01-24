import React from 'react';
import "./Select.scss";

const Select = props => {
    return (
        <select {...props}>
            {props.values.map(v =>
                <option key={v.id}
                        value={v.id}>
                    {v.name}
                </option>
            )}
        </select>
    );
}

export { Select };