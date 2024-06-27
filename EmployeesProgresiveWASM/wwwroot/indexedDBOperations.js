window.indexedDBOperations = {
    db: null,
    isOpen: false, // Track whether the database is already open

    async openDatabase() {
        if (this.db && this.isOpen) {
            return Promise.resolve(); // Database is already open
        }

        return new Promise((resolve, reject) => {
            const request = window.indexedDB.open('EmployeeDatabase', 1);

            request.onerror = (event) => {
                console.error('Error opening database:', event.target.error);
                reject(event.target.error);
            };

            request.onsuccess = (event) => {
                this.db = event.target.result;
                this.isOpen = true; // Mark database as open
                console.log('Database opened successfully');
                resolve();
            };

            request.onupgradeneeded = (event) => {
                const db = event.target.result;
                if (!db.objectStoreNames.contains('employees')) {
                    db.createObjectStore('employees', { keyPath: 'id', autoIncrement: true });
                }
                console.log('Database upgrade needed and performed');
            };
        });
    },

    async addEmployee(employee) {
        if (!this.db) {
            await this.openDatabase();
        }

        // Set LastModified to current time when adding a new employee
        employee.LastModified = new Date().toISOString();

        return new Promise((resolve, reject) => {
            const transaction = this.db.transaction(['employees'], 'readwrite');
            const store = transaction.objectStore('employees');

            transaction.oncomplete = () => {
                console.log('Transaction completed');
                resolve();
            };

            transaction.onerror = (event) => {
                console.error('Transaction error:', event.target.error);
                reject(event.target.error);
            };

            store.get(employee.id).onsuccess = (event) => {
                const existingEmployee = event.target.result;
                if (existingEmployee) {
                    console.log('Employee already exists:', employee.id);
                    reject('Employee already exists');
                } else {
                    const request = store.add(employee);

                    request.onsuccess = (event) => {
                        console.log('Employee added:', event.target.result);
                        resolve(event.target.result);
                    };

                    request.onerror = (event) => {
                        console.error('Error adding employee:', event.target.error);
                        reject(event.target.error);
                    };
                }
            };
        });
    },

    async getEmployees() {
        if (!this.db) {
            await this.openDatabase();
        }

        return new Promise((resolve, reject) => {
            const transaction = this.db.transaction(['employees'], 'readonly');
            const store = transaction.objectStore('employees');

            const request = store.getAll();

            request.onerror = (event) => {
                console.error('Error fetching employees:', event.target.error);
                reject(event.target.error);
            };

            request.onsuccess = (event) => {
                console.log('Employees fetched:', event.target.result);
                resolve(event.target.result);
            };
        });
    },

    async getEmployeeById(id) {
        if (!this.db) {
            await this.openDatabase();
        }

        return new Promise((resolve, reject) => {
            const transaction = this.db.transaction(['employees'], 'readonly');
            const store = transaction.objectStore('employees');

            const request = store.get(id);

            request.onerror = (event) => {
                console.error(`Error fetching employee with id ${id}:`, event.target.error);
                reject(event.target.error);
            };

            request.onsuccess = (event) => {
                console.log('Employee fetched:', event.target.result);
                resolve(event.target.result);
            };
        });
    },

    async updateEmployee(employee) {
        if (!this.db) {
            await this.openDatabase();
        }

        // Update LastModified to current time when updating an existing employee
        employee.LastModified = new Date().toISOString();

        return new Promise((resolve, reject) => {
            const transaction = this.db.transaction(['employees'], 'readwrite');
            const store = transaction.objectStore('employees');

            const request = store.put(employee);

            request.onerror = (event) => {
                console.error('Error updating employee:', event.target.error);
                reject(event.target.error);
            };

            request.onsuccess = (event) => {
                console.log('Employee updated:', event.target.result);
                resolve(event.target.result);
            };
        });
    },

    async deleteEmployee(id) {
        if (!this.db) {
            await this.openDatabase();
        }

        return new Promise((resolve, reject) => {
            const transaction = this.db.transaction(['employees'], 'readwrite');
            const store = transaction.objectStore('employees');

            const request = store.delete(id);

            request.onerror = (event) => {
                console.error(`Error deleting employee with id ${id}:`, event.target.error);
                reject(event.target.error);
            };

            request.onsuccess = (event) => {
                console.log(`Employee with id ${id} deleted`);
                resolve();
            };
        });
    },
};
