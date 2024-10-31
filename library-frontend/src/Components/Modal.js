import React from 'react';
import './Modal.css';

function Modal({ isOpen, onClose, children }) 
{
    if (!isOpen) return null;

    return (
        <div className='container'>
        <div className="modal-overlay">
            <div className="modal-content">
                <button className="close-button" onClick={onClose}>
                    &times;
                </button>
                {children}
            </div>
        </div>
        </div>
    );
}

export default Modal;
