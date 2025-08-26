# --- Build Stage ---
FROM node:22.15 AS build
WORKDIR /app

# Copy package files & install deps
COPY Greenlink.HeroicCharacter.Angular/package*.json ./
RUN ls -la /app
RUN npm install

# Copy source and build
COPY Greenlink.HeroicCharacter.Angular/ .
RUN npm run build -- --configuration production

# --- Runtime Stage (Nginx) ---
FROM nginx:stable
COPY --from=build /app/dist/Greenlink.HeroicCharacter.Angular/browser /usr/share/nginx/html
COPY Greenlink.HeroicCharacter.Angular/nginx.conf /etc/nginx/conf.d/default.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
