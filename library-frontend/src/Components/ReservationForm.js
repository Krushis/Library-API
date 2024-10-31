import React, { useState } from 'react';
import axios from 'axios';

function ReservationForm({ book, onReservationSuccess }) 
{
    const [type, setType] = useState("Book");
    const [quickPickUp, setQuickPickUp] = useState(false);
    const [daysReserved, setDaysReserved] = useState(1);

    function handleReserve() {
        axios.post('http://localhost:5207/api/reservations/reserve', 
            {
                userId: 1,
                bookId: book.id,
                type: type,
                quickPickUp: quickPickUp,
                daysReserved: daysReserved
            })
        .then(response => {
            alert('Reservation successful');
            onReservationSuccess();
        })
        .catch(error => {
            console.error("Error making the reservation", error);
        });
    }

    return (
        <div className='container'>
        <div className="p-4">
            <h2 className="text-xl font-bold mb-4">Reserve {book.name}</h2>
            
            <div className="mt-4">
                <label className="block mb-2">Type</label>
                <select 
                    value={type} 
                    onChange={e => setType(e.target.value)} 
                    className="border rounded p-2 w-full"
                >
                    <option value="Book">Book</option>
                    <option value="Audiobook">Audiobook</option>
                </select>
            </div>
            
            <div className="mt-4">
                <label className="block mb-2">Quick Pickup</label>
                <input 
                    type="checkbox" 
                    checked={quickPickUp} 
                    onChange={() => setQuickPickUp(!quickPickUp)} 
                />
            </div>
            
            <div className="mt-4">
                <label className="block mb-2">Days Reserved</label>
                <input 
                    type="number" 
                    value={daysReserved} 
                    onChange={e => setDaysReserved(e.target.value)} 
                    className="border rounded p-2 w-full" 
                />
            </div>
            
            <button 
                onClick={handleReserve} 
                className="mt-4 bg-green-500 text-white py-2 px-4 rounded"
            >   Confirm Reservation
            </button>
        </div>
        </div>
    );
}

export default ReservationForm;
