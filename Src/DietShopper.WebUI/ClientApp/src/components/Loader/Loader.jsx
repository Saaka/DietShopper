import React from "react";
import "./Loader.scss";

const Loader = (props) => {

    const getLoaderStyle = () => {
        if(props.size === "xs")
            return "lds-dual-ring-xs";
        
        return "lds-dual-ring";
    } 
    
    return (
        <div className={getLoaderStyle()}/>
    );
};

export {Loader};