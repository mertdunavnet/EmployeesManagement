const CACHE_NAME = 'app-cache-v2';
const urlsToCache = [
    '/',
    '/index.html',
    '/manifest.json',
    '/css/bootstrap/bootstrap.min.css',
    '/css/app.css',
    '/favicon.ico',
];

self.addEventListener('install', (event) => {
    event.waitUntil(
        caches.open(CACHE_NAME).then((cache) => {
            return cache.addAll(urlsToCache);
        })
    );
});

self.addEventListener('fetch', (event) => {
    event.respondWith(
        caches.match(event.request).then((response) => {
            return response || fetch(event.request).catch(() => {
                return new Response('Service Unavailable', { status: 503 });
            });
        }).catch((error) => {
            console.error('Fetching failed:', error);
            throw error;
        })
    );
});
