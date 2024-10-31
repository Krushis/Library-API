import React, { useEffect, useState } from 'react';
import axios from 'axios';
import ReservationForm from './ReservationForm';

function UserBooks() 
{
    const [reservations, setReservations] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    
    async function fetchReservations() {
        setLoading(true);
        try {
            const response = await axios.get('http://localhost:5207/api/reservations');
            setReservations(response.data);
        } catch (err) {
            setError('No reservations made by the user');
            console.error("Error fetching reservations:", err);
        } finally {
            setLoading(false);
        }
    }

    useEffect(() => {
        fetchReservations();
    }, []);


    const handleReservationSuccess = () => {
        fetchReservations();
    };

    if (loading) {
        return <div className="p-4">Loading...</div>;
    }

    if (error) {
        return <div className="p-4 text-red-600">{error}</div>;
    }

    return (
        <div className='container'>
        <div className="p-4">
            <h1 className="text-2xl font-bold mb-4">My Reservations</h1>
            {reservations.length === 0 && (
                <ReservationForm 
                    book={{ id: 1, name: "Sample Book" }} 
                    onReservationSuccess={handleReservationSuccess} 
                />
            )}
            {reservations.length === 0 ? (
                <p>No reservations</p>
            ) : (
                <table className="min-w-full border-collapse border border-gray-200">
                    <thead>
                        <tr>
                            <th className="border border-gray-200 p-2">Book</th>
                            <th className="border border-gray-200 p-2">Reservation Date</th>
                            <th className="border border-gray-200 p-2">Cost</th>
                        </tr>
                    </thead>
                    <tbody>
                        {reservations.map(function(reservation) {
                            return (
                                <tr key={reservation.id}>
                                    <td className="border border-gray-200 p-2">{reservation.book.name}</td>
                                    <td className="border border-gray-200 p-2">{new Date(reservation.reservationDate).toLocaleDateString()}</td>
                                    <td className="border border-gray-200 p-2">€{reservation.totalCost.toFixed(2)}</td>
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
            )}
        </div>
        </div>
    );
}

export default UserBooks;
