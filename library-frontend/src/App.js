import React from 'react';
import BookList from './Components/BookList';
import './App.css';
import UserBooks from './Components/UserBooks';
import './styles.css';

function App() {
    return (
        <div className="min-h-screen bg-gray-100">
            <header className="bg-blue-600 text-white p-4">
                <h1 className="text-2xl">Library Reservation System</h1>
            </header>
            <main className="p-4">
                <BookList />
                <UserBooks />
            </main>
        </div>
    );
}

export default App;
