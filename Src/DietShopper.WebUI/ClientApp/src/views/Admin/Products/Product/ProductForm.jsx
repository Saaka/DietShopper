import React, {useEffect, useState} from 'react';

function ProductForm(props) {
    const [title, setTitle] = useState("");

    useEffect(() => {
        let productGuid = props.match.params.productGuid;
        if(!!productGuid)
            setTitle("Edit product");
        else
            setTitle("Create product");
    }, []);
    
    return (
        <section className="columns is-centered">
            <div className="column is-responsive">
                <p className="title has-text-light">Product</p>
                <div className="box">
                    <div className="columns is-mobile subtitle-container">
                        <div className="column">
                            <p className="subtitle">{title}</p>
                        </div>
                    </div>
                    <hr/>
                </div>
            </div>
        </section>
    )
}

export {ProductForm};