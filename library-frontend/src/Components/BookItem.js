import React, { useState } from 'react';
import ReservationForm from './ReservationForm';
import Modal from './Modal';

function BookItem({ book }) 
{
    const [isModalOpen, setIsModalOpen] = useState(false);

    const openModal = () => {
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setIsModalOpen(false);
    };

    return (
        <div className='container'>
        <div className="border rounded-lg p-4 shadow-lg">
            <img src={`http://localhost:5207/images/${book.imagePath}`} alt={book.name} className="w-full h-48 object-cover rounded-md" />
            <h2 className="text-xl font-semibold">{book.name}</h2>
            <p className="text-gray-600">Year: {book.year}</p>
            <button onClick={openModal} className="mt-4 bg-blue-500 text-white py-2 px-4 rounded">
                Reserve
            </button>
            
            <Modal isOpen={isModalOpen} onClose={closeModal}>
                <ReservationForm book={book} />
            </Modal>
        </div>
        </div>
    );
}

export default BookItem;
